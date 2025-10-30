// a Program.cs class has an ”implicit” main-method. I.e. there is no method at all. 
// Method signature is invisible, and the file contains the method body.

using CLI.UI;
using FileRepositories;
using RepositoryContracts;

Console.WriteLine("Starting CLI app...");

IUserRepo userRepo = new UserFileRepo();
ICommentRepo commentRepo = new CommentFileRepo();
IPostRepo postRepo = new PostFileRepo();

// inject into CLI App
var cliApp = new CliApp(userRepo, postRepo, commentRepo);

// start CLI loop
await cliApp.StartAsync();