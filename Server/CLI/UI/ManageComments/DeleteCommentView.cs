using RepositoryContracts;
namespace CLI.UI.ManageComments;

public class DeleteCommentView
{
    private readonly ICommentRepo commentRepo;

    public DeleteCommentView(ICommentRepo commentRepo)
    {
        this.commentRepo = commentRepo;
    }

    public async Task RunAsync()
    {
        Console.Write("Enter comment ID to delete: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int commentId))
        {
            Console.WriteLine("Invalid comment ID. Must be a number.");
            return;
        }

        var comment = commentRepo.GetMany().FirstOrDefault(c => c.Id == commentId);
        if (comment == null)
        {
            Console.WriteLine("Comment not found");
            return;
        }

        await commentRepo.DeleteAsync(comment.Id);
        Console.WriteLine($"Comment ' {comment.Id}' deleted.");
    }
}