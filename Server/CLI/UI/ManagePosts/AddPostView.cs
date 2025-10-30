using Entities;
using RepositoryContracts;
namespace CLI.UI.ManagePosts;

public class AddPostView
{
    private readonly IPostRepo postRepo;

    public AddPostView(IPostRepo postRepo)
    {
        this.postRepo = postRepo;
    }
    
    public async Task RunAsync()
    {
        Console.Write("Enter user ID: ");
        if (!int.TryParse(Console.ReadLine(), out int userId))
        {
            Console.WriteLine("Invalid user ID. Must be a number.");
            return;
        }

        Console.Write("Write title: ");
        string? title = Console.ReadLine();

        Console.Write("Write text: ");
        string? body = Console.ReadLine();

        var post = new Post
        {
            userId = userId,
            title = title ?? string.Empty,
            body = body ?? string.Empty
        };

        await postRepo.AddAsync(post);
        Console.WriteLine($"Post #{post.Id} created.");
    }
    
}