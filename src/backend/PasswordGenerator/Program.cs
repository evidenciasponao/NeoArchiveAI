using BCrypt.Net;

const string password = "Master123*";

var hash = BCrypt.Net.BCrypt.HashPassword(password);

Console.WriteLine();
Console.WriteLine("Password:");
Console.WriteLine(password);

Console.WriteLine();
Console.WriteLine("Hash:");
Console.WriteLine(hash);

Console.WriteLine();
