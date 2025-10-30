// a Program.cs class has an ”implicit” main-method. I.e. there is no method at all. 
// Method signature is invisible, and the file contains the method body.

using CLI.UI;
using InMemoryRepositories;
using RepositoryContracts;

Console.WriteLine("Starting CLI app...");

IUserRepo userRepo = new UserInMemoryRepo();
ICommentRepo commentRepo = new CommentInMemoryRepo();
IPostRepo postRepo = new PostInMemoryRepo();

// inject into CLI App
var cliApp = new CliApp(userRepo, postRepo, commentRepo);

// start CLI loop
await cliApp.StartAsync();