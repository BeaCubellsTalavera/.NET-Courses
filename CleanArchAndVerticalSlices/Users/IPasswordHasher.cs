namespace CleanArchAndVerticalSlices.Users;

public interface IPasswordHasher
{
    string Hash(string password);
}