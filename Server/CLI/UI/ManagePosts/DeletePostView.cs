using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class DeletePostView
{
    private readonly IPostRepo postRepo;

    public DeletePostView(IPostRepo postRepo)
    {
        this.postRepo = postRepo;
    }

    public async Task RunAsync()
    {
        Console.Write("Enter title to delete: ");
        string ? title = Console.ReadLine();

        if (string.IsNullOrEmpty(title))
        {
            Console.WriteLine("Title cannot be empty.");
            return;
        }

        var post = postRepo.GetMany().FirstOrDefault(p => p.title == title);
        if (post == null)
        {
            Console.WriteLine("Post not found.");
            return;
        }

        await postRepo.DeleteAsync(post.Id);
        Console.WriteLine($"Post '{post.title}' deleted.");
    }
}