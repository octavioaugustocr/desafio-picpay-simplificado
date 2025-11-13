using desafio_picpay_simplificado.Data;
using desafio_picpay_simplificado.Dtos;
using desafio_picpay_simplificado.Models;
using Microsoft.EntityFrameworkCore;

namespace desafio_picpay_simplificado.Repositories.User;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<UserModel> GetUserById(int id)
    {
        // return await _appDbContext.User.FirstOrDefaultAsync(u => u.IdUser == id);
        return await _appDbContext.User.FindAsync(id);
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

    public async Task<UserModel> UpdateUserById(int id, UpdateUserDto updateUserDto)
    {
        var userModel = await GetUserById(id);
        
        userModel.FullName = updateUserDto.FullName;
        userModel.Password = updateUserDto.Password;

        _appDbContext.User.Update(userModel);
        await _appDbContext.SaveChangesAsync();
        
        return userModel;
    }

    public async Task<bool> DeleteUserById(int id)
    {
        var userDeleted = _appDbContext.User.Remove(await GetUserById(id))
            .State == EntityState.Deleted;
        await _appDbContext.SaveChangesAsync();
        
        return userDeleted;
    }
}