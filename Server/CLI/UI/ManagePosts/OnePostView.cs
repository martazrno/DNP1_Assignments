using RepositoryContracts;
namespace CLI.UI.ManagePosts;

public class OnePostView
{
    private readonly IPostRepo postRepo;

    public OnePostView(IPostRepo postRepo)
    {
        this.postRepo = postRepo;
    }
    
    public Task RunAsync()
    {
        Console.Write("Enter title to view: ");
        string? title = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Invalid title.");
            return Task.CompletedTask;
        }

        var post = postRepo.GetMany().FirstOrDefault(p => p.title == title);

        if (post == null)
        {
            Console.WriteLine("Post not found.");
            return Task.CompletedTask;
        }

        Console.WriteLine($"\nID: {post.Id}");
        Console.WriteLine($"Title: {post.title}");
        Console.WriteLine($"Body: {post.body}");

        return Task.CompletedTask;
    }
}