using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Models;

namespace desafio_picpay_simplificado.Services.Transfer;

public interface ITransferService
{
    Task<TransferModel> GetTransferById(int id);
    Task<List<TransferModel>> GetAllTransfers();
    Task<TransferModel> MakeTransfer(MakeTransferDto makeTransferDto);
}