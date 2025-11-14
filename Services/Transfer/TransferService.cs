using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Models;
using desafio_picpay_simplificado.Repositories.Transfer;

namespace desafio_picpay_simplificado.Services.Transfer;

public class TransferService : ITransferService
{
    private readonly ITransferRepository _transferRepository;

    public TransferService(ITransferRepository transferRepository)
    {
        _transferRepository = transferRepository;
    }

    public async Task<TransferModel> GetTransferById(int id)
    {
        return await _transferRepository.GetTransferById(id);
    }

    public async Task<List<TransferModel>> GetAllTransfers()
    {
        return await _transferRepository.GetAllTransfers();
    }

    public async Task<TransferModel> MakeTransfer(MakeTransferDto makeTransferDto)
    {
        return await _transferRepository.MakeTransfer(makeTransferDto);
    }
}