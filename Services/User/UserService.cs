using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Models;
using desafio_picpay_simplificado.Repositories.User;

namespace desafio_picpay_simplificado.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserModel> GetUserById(int id)
    {
        return await _userRepository.GetUserById(id);
    }

    public async Task<List<UserModel>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }
    
    public async Task<int> CreateUser(CreateUserDto createUserDto)
    {
        return await _userRepository.CreateUser(createUserDto);
    }
}