using desafio_picpay_simplificado.Data;
using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Models;

namespace desafio_picpay_simplificado.Repositories.User;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<List<UserModel>> GetAllUsers()
    {
        return _appDbContext.User.ToList();
    }

    public async Task<int> CreateUser(CreateUserDto createUserDto)
    {
        var userModel = new UserModel()
        {
            FullName = createUserDto.FullName,
            CpfCnpj = createUserDto.CpfCnpj,
            Email = createUserDto.Email,
            Password = createUserDto.Password,
            TypeUser = createUserDto.TypeUser
        };

        await _appDbContext.User.AddAsync(userModel);
        await _appDbContext.SaveChangesAsync();

        return userModel.IdUser;
    }
}