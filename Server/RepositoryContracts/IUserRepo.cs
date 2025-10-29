using Entities;
namespace RepositoryContracts;

public interface IUserRepo
{
    Task<User> AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int Id);
    Task<User> GetSingleAsync(int Id);
    IQueryable<User> GetMany();
}