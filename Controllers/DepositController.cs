using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Services.Deposit;
using Microsoft.AspNetCore.Mvc;

namespace desafio_picpay_simplificado.Controllers;

[ApiController]
[Route("/picpaysimplificado/v1/")]
public class DepositController : ControllerBase
{
    private readonly IDepositService _depositService;

    public DepositController(IDepositService depositService)
    {
        _depositService = depositService;
    }

    [HttpPost]
    [Route("deposit")]
    public async Task<IActionResult> MakeDepositByIdUser(MakeDepositDto makeDepositDto)
    {
        return Ok(await _depositService.MakeDepositByIdUser(makeDepositDto));
    }
}