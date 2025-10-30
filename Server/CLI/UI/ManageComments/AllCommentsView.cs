using RepositoryContracts;
namespace CLI.UI.ManageComments;

public class AllCommentsView
{
    private readonly ICommentRepo commentRepo;

    public AllCommentsView(ICommentRepo commentRepo)
    {
        this.commentRepo = commentRepo;
    }
    
    public void Run()
    {
        Console.WriteLine("Listing comments...");

        var comments = commentRepo.GetMany().ToList();

        foreach (var comment in comments)
        {
            Console.WriteLine($"#{comment.Id} - {comment.body}");
        }
    }
}