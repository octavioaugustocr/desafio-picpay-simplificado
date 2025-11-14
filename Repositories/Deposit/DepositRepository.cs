using desafio_picpay_simplificado.Data;
using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Models;
using Microsoft.EntityFrameworkCore;

namespace desafio_picpay_simplificado.Repositories.Deposit;

public class DepositRepository : IDepositRepository
{
    private readonly AppDbContext _appDbContext;

    public DepositRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    private bool MakeDeposit(MakeDepositDto makeDepositDto, UserModel userModel)
    {
        userModel.Balance += makeDepositDto.Amount;
        _appDbContext.User.Update(userModel);
        _appDbContext.SaveChanges();

        return true;
    }

    public async Task<DepositModel> GetDepositById(int id)
    {
        return await _appDbContext.Deposit.FindAsync(id);
    }

    public async Task<List<DepositModel>> GetAllDeposits()
    {
        return await _appDbContext.Deposit.ToListAsync();
    }

    public async Task<DepositModel> MakeDepositByIdUser(MakeDepositDto makeDepositDto)
    {
        var userModel = await _appDbContext.User.FirstOrDefaultAsync(u => u.IdUser == makeDepositDto.IdUser);
        if (userModel == null) return null;

        if (!MakeDeposit(makeDepositDto, userModel)) return null;
        
        var depositModel = new DepositModel()
        {
            IdUser = makeDepositDto.IdUser,
            Amount = makeDepositDto.Amount,
            Date = DateTime.Now
        };
        
        await _appDbContext.Deposit.AddAsync(depositModel);
        await _appDbContext.SaveChangesAsync();
        
        return depositModel;
    }
}