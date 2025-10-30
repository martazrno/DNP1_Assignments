using System.Text.Json;
using Entities;
using RepositoryContracts;
namespace FileRepositories;

public class CommentFileRepo : ICommentRepo
{
	private readonly string filePath = "comments.json";

	public CommentFileRepo()
	{
		if (!File.Exists(filePath))
		{
			File.WriteAllText(filePath, "[]");
		}
	}
	
	private async Task<List<Comment>> LoadCommentsAsync()
	{
		string commentsAsJson = await File.ReadAllTextAsync(filePath);
		return JsonSerializer.Deserialize<List<Comment>>(commentsAsJson)!;
	}
	
	private async Task SaveCommentsAsync(List<Comment> comments)
	{
		string commentsAsJson = JsonSerializer.Serialize(comments);
		await File.WriteAllTextAsync(filePath, commentsAsJson);
	}
	
	public async Task<Comment> AddAsync(Comment comment)
	{
		var comments = await LoadCommentsAsync();

		int maxId = comments.Count > 0 ? comments.Max(c => c.Id) : 0;
		comment.Id = maxId + 1;

		comments.Add(comment);
		await SaveCommentsAsync(comments);

		return comment;
	}
	
	public async Task UpdateAsync(Comment comment)
	{
		var comments = await LoadCommentsAsync();

		var existing = comments.FirstOrDefault(c => c.Id == comment.Id);
		if (existing == null)
			throw new KeyNotFoundException($"Comment with ID {comment.Id} not found.");
		
		int index = comments.IndexOf(existing);
		comments[index] = comment;

		await SaveCommentsAsync(comments);
	}

	public async Task DeleteAsync(int Id)
	{
		var comments = await LoadCommentsAsync();

		var existing = comments.FirstOrDefault(c => c.Id == Id);
		if (existing == null)
			throw new KeyNotFoundException($"Comment with ID {Id} not found.");

		comments.Remove(existing);
		await SaveCommentsAsync(comments);
	}

	public async Task<Comment> GetSingleAsync(int Id)
	{
		var comments = await LoadCommentsAsync();
		
		var existing = comments.FirstOrDefault(c => c.Id == Id);
		if (existing == null)
			throw new KeyNotFoundException($"Comment with ID {Id} not found.");

		return existing;
	}

	public IQueryable<Comment> GetMany()
	{
		string commentsAsJson = File.ReadAllTextAsync(filePath).Result;
		List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson)!;
		return comments.AsQueryable();
	}
}