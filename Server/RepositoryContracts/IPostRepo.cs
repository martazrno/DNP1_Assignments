using Entities;
namespace RepositoryContracts;

public interface IPostRepo
{
    Task<Post> AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(int Id);
    Task<Post> GetSingleAsync(int Id);
    IQueryable<Post> GetMany();

}