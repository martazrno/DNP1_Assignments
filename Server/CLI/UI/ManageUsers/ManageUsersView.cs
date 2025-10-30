using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class ManageUsersView
{
    private readonly IUserRepo userRepo;

    public ManageUsersView(IUserRepo userRepo)
    {
        this.userRepo = userRepo;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("--Choose an option--");
            Console.WriteLine("1) Add user");
            Console.WriteLine("2) Update user");
            Console.WriteLine("3) Delete user");
            Console.WriteLine("4) Get a user");
            Console.WriteLine("5) Get all users");
            Console.WriteLine("6) Exit view.");
            Console.WriteLine("Choice: ");
            string ? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await new AddUserView(userRepo).RunAsync();
                    break;
                case "2":
                    await new UpdateUserView(userRepo).RunAsync();
                    break;
                case "3":
                    await new DeleteUserView(userRepo).RunAsync();
                    break;
                case "4":
                    await new OneUserView(userRepo).RunAsync();
                    break;
                case "5":
                    new AllUsersView(userRepo).Run();
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