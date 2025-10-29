using Entities;
using RepositoryContracts;
namespace InMemoryRepositories;

public class CommentInMemoryRepo : ICommentRepo
{
    private List<Comment> comments;

    public CommentInMemoryRepo()
    {
        comments = new List<Comment>();
    }

    public Task<Comment> AddAsync(Comment comment)
    {
        comment.Id = comments.Any()
            ? comments.Max(p => p.Id) + 1
            : 1;
        comments.Add(comment);
        return Task.FromResult(comment);
    }

    public Task UpdateAsync(Comment comment)
    {
        Comment? existingComment = comments.SingleOrDefault(p => p.Id == comment.Id);
        if (existingComment is null)
            throw new InvalidOperationException($"Comment with ID '{comment.Id}' not found");

        comments.Remove(existingComment);
        comments.Add(comment);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int Id)
    {
        Comment? commentToRemove = comments.SingleOrDefault(p => p.Id == Id);
        if (commentToRemove is null)
            throw new InvalidOperationException($"User with ID '{Id}' not found");

        comments.Remove(commentToRemove);
        return Task.CompletedTask;
    }

    public Task<Comment> GetSingleAsync(int Id)
    {
        Comment? comment = comments.SingleOrDefault(p => p.Id == Id);
        if (comment is null)
            throw new InvalidOperationException($"Comment with ID '{Id}' not found");

        return Task.FromResult(comment);
    }

    public IQueryable<Comment> GetMany()
    {
        return comments.AsQueryable();
    }
        
}