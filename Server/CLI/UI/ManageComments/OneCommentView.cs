using RepositoryContracts;
namespace CLI.UI.ManageComments;

public class OneCommentView
{
    private readonly ICommentRepo commentRepo;

    public OneCommentView(ICommentRepo commentRepo)
    {
        this.commentRepo = commentRepo;
    }
    
    public Task RunAsync()
    {
        Console.Write("Enter comment ID to view: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int commentId))
        {
            Console.WriteLine("Invalid comment ID. Must be a number.");
            return Task.CompletedTask;
        }

        var comment = commentRepo.GetMany().FirstOrDefault(c => c.Id == commentId);

        if (comment == null)
        {
            Console.WriteLine("Comment not found.");
            return Task.CompletedTask;
        }

        Console.WriteLine($"\nID: {comment.Id}");
        Console.WriteLine($"Body: {comment.body}");

        return Task.CompletedTask;
    }
}