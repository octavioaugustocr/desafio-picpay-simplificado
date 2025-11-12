using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Models;

namespace desafio_picpay_simplificado.Repositories.User;

public interface IUserRepository
{
    Task<List<UserModel>> GetAllUsers();
    Task<int> CreateUser(CreateUserDto createUserDto);
}