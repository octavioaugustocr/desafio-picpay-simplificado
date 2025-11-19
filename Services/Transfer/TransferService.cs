using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Enums;
using desafio_picpay_simplificado.Models;
using desafio_picpay_simplificado.Repositories.Transfer;
using desafio_picpay_simplificado.Services.User;

namespace desafio_picpay_simplificado.Services.Transfer;

public class TransferService : ITransferService
{
    private readonly ITransferRepository _transferRepository;
    private readonly IUserService _userService;

    public TransferService(ITransferRepository transferRepository, IUserService userService)
    {
        _transferRepository = transferRepository;
        _userService = userService;
    }
    
    private async Task<bool> ExternalAuthorizationService()
    {
        var client = new HttpClient();

        var response = await client.GetAsync("https://util.devi.tools/api/v2/authorize");
        if (!response.IsSuccessStatusCode) return false;
        
        return true;
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
        return await _transferRepository.GetTransferById(id);
    }

    public async Task<List<TransferModel>> GetAllTransfers()
    {
        return await _transferRepository.GetAllTransfers();
    }
    
    private async Task<bool> ValidationsTransfer(MakeTransferDto makeTransferDto)
    {
        if (makeTransferDto.Payer == makeTransferDto.Payee) return false;
        
        var payer = await _userService.GetUserById(makeTransferDto.Payer);
        var payee = await _userService.GetUserById(makeTransferDto.Payee);
        if (payer == null || payee == null) return false;
        
        if (payer.TypeUser == TypeUserEnum.Merchant) return false;
        if (payer.Balance < makeTransferDto.Value) return false;
        
        var responseExternalAuthorization = await ExternalAuthorizationService();
        if (!responseExternalAuthorization) return false;

        return true;
    }

    public async Task<TransferModel> MakeTransfer(MakeTransferDto makeTransferDto)
    {
        var response = await ValidationsTransfer(makeTransferDto);
        if (!response) return null;
        
        var makeTransferResponse = await _transferRepository.MakeTransfer(makeTransferDto);
        if (makeTransferResponse == null) return null;

        await SendTransferNotification();
        return makeTransferResponse;
    }
}