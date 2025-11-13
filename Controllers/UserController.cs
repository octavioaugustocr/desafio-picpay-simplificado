using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace desafio_picpay_simplificado.Controllers;

[ApiController]
[Route("/picpaysimplificado/v1/")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        return Ok(await _userService.GetUserById(id));
    }

    [HttpGet]
    [Route("users")]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await _userService.GetAllUsers());
    }
    
    [HttpPost]
    [Route("user")]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        return Ok(await _userService.CreateUser(createUserDto));
    }

    [HttpDelete]
    [Route("user/delete/{id}")]
    public async Task<IActionResult> DeleteUserById(int id)
    {
        return Ok(await _userService.DeleteUserById(id));
    }
}