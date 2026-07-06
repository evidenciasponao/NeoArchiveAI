namespace NeoArchiveAI.Application.Abstractions.Hashing;

public interface IPasswordHasher
{
    string Hash(string password);

    bool Verify(string password, string passwordHash);
}