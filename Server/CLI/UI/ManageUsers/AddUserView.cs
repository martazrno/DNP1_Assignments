using Entities;
using RepositoryContracts;
namespace CLI.UI.ManageUsers;

public class AddUserView
{
    private readonly IUserRepo userRepo;

    public AddUserView(IUserRepo userRepo)
    {
        this.userRepo = userRepo;
    }
    
    public async Task RunAsync()
    {
        Console.Write("Username: ");
        string? username = Console.ReadLine();

        Console.Write("Password: ");
        string ? password = Console.ReadLine();

        var user = new User
        {
            username = username ?? string.Empty,
            password = password ?? string.Empty
        };

        await userRepo.AddAsync(user);
        Console.WriteLine($"User #{user.Id} created.");
    }
}