using System.Text.Json;
using Entities;
using RepositoryContracts;
namespace FileRepositories;

public class UserFileRepo : IUserRepo
{
	private readonly string filePath = "users.json";

	public UserFileRepo()
	{
		if (!File.Exists(filePath))
		{
			File.WriteAllText(filePath, "[]");
		}
	}
	
	private async Task<List<User>> LoadUsersAsync()
	{
		string usersAsJson = await File.ReadAllTextAsync(filePath);
		return JsonSerializer.Deserialize<List<User>>(usersAsJson)!;
	}
	
	private async Task SaveUsersAsync(List<User> users)
	{
		string usersAsJson = JsonSerializer.Serialize(users);
		await File.WriteAllTextAsync(filePath, usersAsJson);
	}
	
	public async Task<User> AddAsync(User user)
	{
		var users = await LoadUsersAsync();

		int maxId = users.Count > 0 ? users.Max(c => c.Id) : 0;
		user.Id = maxId + 1;

		users.Add(user);
		await SaveUsersAsync(users);

		return user;
	}
	
	public async Task UpdateAsync(User user)
	{
		var users = await LoadUsersAsync();

		var existing = users.FirstOrDefault(c => c.Id == user.Id);
		if (existing == null)
			throw new KeyNotFoundException($"User with ID {user.Id} not found.");
		
		int index = users.IndexOf(existing);
		users[index] = user;

		await SaveUsersAsync(users);
	}

	public async Task DeleteAsync(int Id)
	{
		var users = await LoadUsersAsync();

		var existing = users.FirstOrDefault(c => c.Id == Id);
		if (existing == null)
			throw new KeyNotFoundException($"User with ID {Id} not found.");

		users.Remove(existing);
		await SaveUsersAsync(users);
	}

	public async Task<User> GetSingleAsync(int Id)
	{
		var users = await LoadUsersAsync();
		
		var existing = users.FirstOrDefault(c => c.Id == Id);
		if (existing == null)
			throw new KeyNotFoundException($"User with ID {Id} not found.");

		return existing;
	}

	public IQueryable<User> GetMany()
	{
		string usersAsJson = File.ReadAllTextAsync(filePath).Result;
		List<User> users = JsonSerializer.Deserialize<List<User>>(usersAsJson)!;
		return users.AsQueryable();
	}
}