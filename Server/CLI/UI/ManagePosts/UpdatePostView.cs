using RepositoryContracts;
namespace CLI.UI.ManagePosts;

public class UpdatePostView
{
    private IPostRepo postRepo;

    public UpdatePostView(IPostRepo postRepo)
    {
        this.postRepo = postRepo;
    }

    public async Task RunAsync()
    {
        Console.Write("Enter title to update: ");
        string? title = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Invalid title.");
            return;
        }

        var post = postRepo.GetMany().FirstOrDefault(p => p.title == title);
        if (post == null)
        {
            Console.WriteLine("Post not found.");
            return;
        }
        
        Console.Write($"New title (current: {post.title}): ");
        string? newTitle = Console.ReadLine();

        Console.Write($"New text (current: {post.body}): ");
        string? newBody = Console.ReadLine();
        
        post.title = string.IsNullOrWhiteSpace(newTitle) ? post.title : newTitle;
        post.body = string.IsNullOrWhiteSpace(newBody) ? post.body : newBody;

        await postRepo.UpdateAsync(post);

        Console.WriteLine($"Post '{post.title}' updated.");




    }
}