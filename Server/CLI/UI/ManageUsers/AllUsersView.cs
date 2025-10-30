using RepositoryContracts;
namespace CLI.UI.ManageUsers;

public class AllUsersView
{
    private readonly IUserRepo userRepo;

    public AllUsersView(IUserRepo userRepo)
    {
        this.userRepo = userRepo;
    }

    public void Run()
    {
        Console.WriteLine("Listing users...");

        var users = userRepo.GetMany().ToList();

        foreach (var user in users)
        {
            Console.WriteLine($"#{user.Id} - {user.username}");
        }
    }
}