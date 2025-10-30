using CLI.UI.ManagePosts;
using RepositoryContracts;
namespace CLI.UI.ManagePosts;

public class ManagePostsView
{
    private readonly IPostRepo postRepo;

    public ManagePostsView(IPostRepo postRepo)
    {
        this.postRepo = postRepo;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("--Choose an option--");
            Console.WriteLine("1) Add post");
            Console.WriteLine("2) Update post");
            Console.WriteLine("3) Delete post");
            Console.WriteLine("4) Get a post");
            Console.WriteLine("5) Get all posts");
            Console.WriteLine("6) Exit view.");
            Console.WriteLine("Choice: ");
            string ? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await new AddPostView(postRepo).RunAsync();
                    break;
                case "2":
                    await new UpdatePostView(postRepo).RunAsync();
                    break;
                case "3":
                    await new DeletePostView(postRepo).RunAsync();
                    break;
                case "4":
                    await new OnePostView(postRepo).RunAsync();
                    break;
                case "5":
                    new AllPostsView(postRepo).Run();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
    
    
    
    
}