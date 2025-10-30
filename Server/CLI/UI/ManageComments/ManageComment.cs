using RepositoryContracts;
namespace CLI.UI.ManageComments;

public class ManageCommentsView
{
    private readonly ICommentRepo commentRepo;

    public ManageCommentsView(ICommentRepo commentRepo)
    {
        this.commentRepo = commentRepo;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("--Choose an option--");
            Console.WriteLine("1) Add comment");
            Console.WriteLine("2) Update comment");
            Console.WriteLine("3) Delete comment");
            Console.WriteLine("4) Get a comment");
            Console.WriteLine("5) Get all comment");
            Console.WriteLine("6) Exit view.");
            Console.WriteLine("Choice: ");
            string ? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await new AddCommentView(commentRepo).RunAsync();
                    break;
                case "2":
                    await new UpdateCommentView(commentRepo).RunAsync();
                    break;
                case "3":
                    await new DeleteCommentView(commentRepo).RunAsync();
                    break;
                case "4":
                    await new OneCommentView(commentRepo).RunAsync();
                    break;
                case "5":
                    new AllCommentsView(commentRepo).Run();
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