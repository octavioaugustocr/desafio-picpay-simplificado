using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Models;
using desafio_picpay_simplificado.Repositories.Deposit;

namespace desafio_picpay_simplificado.Services.Deposit;

public class DepositService : IDepositService
{
    private readonly IDepositRepository _depositRepository;

    public DepositService(IDepositRepository depositRepository)
    {
        _depositRepository = depositRepository;
    }

    public async Task<List<DepositModel>> GetAllDeposits()
    {
        return await _depositRepository.GetAllDeposits();
    }

    public async Task<DepositModel> MakeDepositByIdUser(MakeDepositDto makeDepositDto)
    {
        return await _depositRepository.MakeDepositByIdUser(makeDepositDto);
    }
}