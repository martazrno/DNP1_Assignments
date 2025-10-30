using RepositoryContracts;

namespace CLI.UI.ManageComments;

public class UpdateCommentView
{
    private readonly ICommentRepo commentRepo;

    public UpdateCommentView(ICommentRepo commentRepo)
    {
        this.commentRepo = commentRepo;
    }

    public Task RunAsync()
    {
        var comments = commentRepo.GetMany().ToList();

        if (!comments.Any())
        {
            Console.WriteLine("No comments found.");
            return Task.CompletedTask;
        }

        Console.WriteLine("\nAll comments: ");
        foreach (var comment in comments)
        {
            Console.WriteLine($"ID: {comment.Id} | Body: {comment.body} | User ID: {comment.userId} | Post ID: {comment.postId}");
        }

        return Task.CompletedTask;
    }
}