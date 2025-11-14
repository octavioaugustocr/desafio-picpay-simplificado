using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Models;

namespace desafio_picpay_simplificado.Repositories.Transfer;

public interface ITransferRepository
{
    Task<List<TransferModel>> GetAllTransfers();
    Task<TransferModel> MakeTransfer(MakeTransferDto makeTransferDto);
}