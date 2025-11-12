using desafio_picpay_simplificado.Dtos;

namespace desafio_picpay_simplificado.Repositories.User;

public interface IUserRepository
{
    Task<int> CreateUser(CreateUserDto createUserDto);
}