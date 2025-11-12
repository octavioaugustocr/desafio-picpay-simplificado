using desafio_picpay_simplificado.Dtos;

namespace desafio_picpay_simplificado.Services.User;

public interface IUserService
{
    Task<int> CreateUser(CreateUserDto createUserDto);
}