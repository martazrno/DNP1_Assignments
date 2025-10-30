using RepositoryContracts;
namespace CLI.UI.ManagePosts;

public class AllPostsView
{
    private readonly IPostRepo postRepo;

    public AllPostsView(IPostRepo postRepo)
    {
        this.postRepo = postRepo;
    }
    
    public void Run()
    {
        Console.WriteLine("Listing posts...");

        var posts = postRepo.GetMany().ToList();

        foreach (var post in posts)
        {
            Console.WriteLine($"#{post.Id} - {post.title}");
        }
    }
}