using RepositoryContracts;
namespace CLI.UI.ManageUsers;

public class OneUserView
{
    private readonly IUserRepo userRepo;

    public OneUserView(IUserRepo userRepo)
    {
        this.userRepo = userRepo;
    }

    public Task RunAsync()
    {
        Console.Write("Enter username to view: ");
        string? username = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("Invalid username.");
            return Task.CompletedTask;
        }

        var user = userRepo.GetMany().FirstOrDefault(u => u.username == username);

        if (user == null)
        {
            Console.WriteLine("User not found.");
            return Task.CompletedTask;
        }

        Console.WriteLine($"\nID: {user.Id}");
        Console.WriteLine($"Username: {user.username}");
        Console.WriteLine($"Password: {user.password}");

        return Task.CompletedTask;
    }
}