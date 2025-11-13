using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Models;

namespace desafio_picpay_simplificado.Repositories.User;

public interface IUserRepository
{
    Task<UserModel> GetUserById(int id);
    Task<List<UserModel>> GetAllUsers();
    Task<int> CreateUser(CreateUserDto createUserDto);
    Task<bool> DeleteUserById(int id);
}