using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Models;

namespace desafio_picpay_simplificado.Services.User;

public interface IUserService
{
    Task<UserModel> GetUserById(int id);
    Task<List<UserModel>> GetAllUsers();
    Task<int> CreateUser(CreateUserDto createUserDto);
    Task<UserModel> UpdateUserById(int id, UpdateUserDto updateUserDto);
    Task<bool> DeleteUserById(int id);
}