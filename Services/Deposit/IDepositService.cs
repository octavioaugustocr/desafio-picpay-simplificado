using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Models;

namespace desafio_picpay_simplificado.Services.Deposit;

public interface IDepositService
{
    Task<DepositModel> MakeDepositByIdUser(MakeDepositDto makeDepositDto);
}