using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Models;

namespace desafio_picpay_simplificado.Repositories.Deposit;

public interface IDepositRepository
{
    Task<List<DepositModel>> GetAllDeposits();
    Task<DepositModel> MakeDepositByIdUser(MakeDepositDto makeDepositDto);
}