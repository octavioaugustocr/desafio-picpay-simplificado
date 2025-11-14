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

    [HttpGet]
    [Route("deposit/{id}")]
    public async Task<IActionResult> GetDepositById(int id)
    {
        return Ok(await _depositService.GetDepositById(id));
    }

    [HttpGet]
    [Route("deposits")]
    public async Task<IActionResult> GetAllDeposits()
    {
        return Ok(await _depositService.GetAllDeposits());
    }

    [HttpPost]
    [Route("deposit")]
    public async Task<IActionResult> MakeDepositByIdUser(MakeDepositDto makeDepositDto)
    {
        return Ok(await _depositService.MakeDepositByIdUser(makeDepositDto));
    }
}