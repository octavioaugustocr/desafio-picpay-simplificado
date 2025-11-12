using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Repositories.User;

namespace desafio_picpay_simplificado.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<int> CreateUser(CreateUserDto createUserDto)
    {
        return await _userRepository.CreateUser(createUserDto);
    }
}