using Entities;
using RepositoryContracts;
namespace CLI.UI.ManageComments;

public class AddCommentView
{
    private readonly ICommentRepo commentRepo;

    public AddCommentView(ICommentRepo commentRepo)
    {
        this.commentRepo = commentRepo;
    }
    
    public async Task RunAsync()
    {
        Console.Write("Write comment: ");
        string? body = Console.ReadLine();

        Console.Write("Write userID: ");
        int userId = int.Parse(Console.ReadLine());
        
        Console.Write("Write postID: ");
        int postId = int.Parse(Console.ReadLine());

        var comment = new Comment
        {
            body = body ?? string.Empty,
            postId = postId,
            userId = userId
        };

        await commentRepo.AddAsync(comment);
        Console.WriteLine($"Comment #{comment.Id} created.");
    }
    
}