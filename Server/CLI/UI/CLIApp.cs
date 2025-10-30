using RepositoryContracts;
using CLI.UI.ManageUsers;
using CLI.UI.ManagePosts;
using CLI.UI.ManageComments;

namespace CLI.UI
{
    public class CliApp
    {
        private readonly IUserRepo _userRepo;
        private readonly IPostRepo _postRepo;
        private readonly ICommentRepo _commentRepo;

        public CliApp(IUserRepo userRepo, IPostRepo postRepo, ICommentRepo commentRepo)
        {
            _userRepo = userRepo;
            _postRepo = postRepo;
            _commentRepo = commentRepo;
        }

        public async Task StartAsync()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Forum CLI ===");
                Console.WriteLine("1. Manage users");
                Console.WriteLine("2. Manage posts");
                Console.WriteLine("3. Manage comments");
                Console.WriteLine("0. Exit program.");
                Console.Write("Select option: ");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        var manageUsers = new ManageUsersView(_userRepo);
                        await manageUsers.RunAsync();
                        break;

                    case "2":
                        var managePosts = new ManagePostsView(_postRepo);
                        await managePosts.RunAsync();
                        break;

                    case "3":
                        var manageComments = new ManageCommentsView(_commentRepo);
                        await manageComments.RunAsync();
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}