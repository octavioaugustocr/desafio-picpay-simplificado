using desafio_picpay_simplificado.Data;
using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Enums;
using desafio_picpay_simplificado.Models;
using Microsoft.EntityFrameworkCore;

namespace desafio_picpay_simplificado.Repositories.Transfer;

public class TransferRepository : ITransferRepository
{
    private readonly AppDbContext _appDbContext;

    public TransferRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    private async Task<bool> ExternalAuthorizationService()
    {
        var client = new HttpClient();

        var response = await client.GetAsync("https://util.devi.tools/api/v2/authorize");
        if (!response.IsSuccessStatusCode) return false;
        
        return true;
    }

    private async Task<bool> ValidationsTransfer(MakeTransferDto makeTransferDto)
    {
        if (makeTransferDto.Payer == makeTransferDto.Payee) return false;
        
        var payer = _appDbContext.User.Find(makeTransferDto.Payer);
        var payee = _appDbContext.User.Find(makeTransferDto.Payee);
        if (payer == null || payee == null) return false;
        
        if (payer.TypeUser == TypeUserEnum.Merchant) return false;
        if (payer.Balance < makeTransferDto.Value) return false;
        
        var responseExternalAuthorization = await ExternalAuthorizationService();
        if (!responseExternalAuthorization) return false;

        return true;
    }

    private async Task<bool> FinalizeTransfer(MakeTransferDto makeTransferDto)
    {
        try
        {
            var payer = _appDbContext.User.Find(makeTransferDto.Payer);
            var payee = _appDbContext.User.Find(makeTransferDto.Payee);
        
            payer.Balance -= makeTransferDto.Value;
            payee.Balance += makeTransferDto.Value;

            _appDbContext.User.Update(payer);
            _appDbContext.User.Update(payee);
            await _appDbContext.SaveChangesAsync();
        
            return true; 
        } catch (Exception)
        {
            return false;
        }
    }

    private async Task<bool> SendTransferNotification()
    {
        var client = new HttpClient();
        
        var response = await client.GetAsync("https://util.devi.tools/api/v1/notify");
        if (!response.IsSuccessStatusCode) return false;
        
        // Enviar notificação..
        return true;
    }

    public async Task<TransferModel> GetTransferById(int id)
    {
        return await _appDbContext.Transfer.FindAsync(id);
    }

    public async Task<List<TransferModel>> GetAllTransfers()
    {
        return await _appDbContext.Transfer.ToListAsync();
    }

    public async Task<TransferModel> MakeTransfer(MakeTransferDto makeTransferDto)
    {
        var response = await ValidationsTransfer(makeTransferDto);
        if (!response) return null;

        var transferModel = new TransferModel()
        {
            Value = makeTransferDto.Value,
            Payer = makeTransferDto.Payer,
            Payee = makeTransferDto.Payee,
            Date =  DateTime.Now
        };

        await _appDbContext.Transfer.AddAsync(transferModel);
        if (!await FinalizeTransfer(makeTransferDto)) return null;
        
        await _appDbContext.SaveChangesAsync();
        
        await SendTransferNotification();
        
        return transferModel;
    }
}