using System.Text.Json;
using Entities;
using RepositoryContracts;
namespace FileRepositories;

public class PostFileRepo : IPostRepo
{
	private readonly string filePath = "posts.json";

	public PostFileRepo()
	{
		if (!File.Exists(filePath))
		{
			File.WriteAllText(filePath, "[]");
		}
	}
	
	private async Task<List<Post>> LoadPostsAsync()
	{
		string postsAsJson = await File.ReadAllTextAsync(filePath);
		return JsonSerializer.Deserialize<List<Post>>(postsAsJson)!;
	}
	
	private async Task SavePostsAsync(List<Post> posts)
	{
		string postsAsJson = JsonSerializer.Serialize(posts);
		await File.WriteAllTextAsync(filePath, postsAsJson);
	}
	
	public async Task<Post> AddAsync(Post post)
	{
		var posts = await LoadPostsAsync();

		int maxId = posts.Count > 0 ? posts.Max(c => c.Id) : 0;
		post.Id = maxId + 1;

		posts.Add(post);
		await SavePostsAsync(posts);

		return post;
	}
	
	public async Task UpdateAsync(Post post)
	{
		var posts = await LoadPostsAsync();

		var existing = posts.FirstOrDefault(c => c.Id == post.Id);
		if (existing == null)
			throw new KeyNotFoundException($"Post with ID {post.Id} not found.");
		
		int index = posts.IndexOf(existing);
		posts[index] = post;

		await SavePostsAsync(posts);
	}

	public async Task DeleteAsync(int Id)
	{
		var posts = await LoadPostsAsync();

		var existing = posts.FirstOrDefault(c => c.Id == Id);
		if (existing == null)
			throw new KeyNotFoundException($"Post with ID {Id} not found.");

		posts.Remove(existing);
		await SavePostsAsync(posts);
	}

	public async Task<Post> GetSingleAsync(int Id)
	{
		var posts = await LoadPostsAsync();
		
		var existing = posts.FirstOrDefault(c => c.Id == Id);
		if (existing == null)
			throw new KeyNotFoundException($"Posts with ID {Id} not found.");

		return existing;
	}

	public IQueryable<Post> GetMany()
	{
		string postsAsJson = File.ReadAllTextAsync(filePath).Result;
		List<Post> posts = JsonSerializer.Deserialize<List<Post>>(postsAsJson)!;
		return posts.AsQueryable();
	}
}