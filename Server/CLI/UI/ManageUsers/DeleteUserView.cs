using Entities;
using RepositoryContracts;
using System.Linq;
namespace CLI.UI.ManageUsers;

public class DeleteUserView
{
    private readonly IUserRepo userRepo;

    public DeleteUserView(IUserRepo userRepo)
    {
        this.userRepo = userRepo;
    }

    public async Task RunAsync()
    {
        Console.Write("Enter username to delete: ");
        string? username = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("Invalid username.");
            return;
        }
        
        var user = userRepo.GetMany().FirstOrDefault(u => u.username == username);
        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }
        
        await userRepo.DeleteAsync(user.Id);

        Console.WriteLine($"User '{user.username}' deleted successfully!");
    }
}