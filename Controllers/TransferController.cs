using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Services.Transfer;
using desafio_picpay_simplificado.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace desafio_picpay_simplificado.Controllers;

[ApiController]
[Route("/picpaysimplificado/v1/")]
public class TransferController : ControllerBase
{
    private readonly ITransferService _transferService;
    
    public TransferController(ITransferService transferService)
    {
        _transferService = transferService;
    }

    [HttpPost]
    [Route("transfer")]
    public async Task<IActionResult> MakeTransfer(MakeTransferDto makeTransferDto)
    {
        return Ok(await _transferService.MakeTransfer(makeTransferDto));
    }
}