using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace desafio_picpay_simplificado.Controllers;

[ApiController]
[Route("/v1/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        return Ok(await _userService.CreateUser(createUserDto));
    }
}