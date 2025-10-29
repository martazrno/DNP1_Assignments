using Entities;
namespace RepositoryContracts;

public interface ICommentRepo
{
    Task<Comment> AddAsync(Comment comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(int Id);
    Task<Comment> GetSingleAsync(int Id);
    IQueryable<Comment> GetMany();

}