namespace CleanArchAndVerticalSlices.Users;

// Clean Architecture Principles
// When we need to interact with an external facing service (databse, email service, file system, etc)
// we need to define a respective abstraction
public interface IUserRepository
{
    Task Insert(User user);
    Task<bool> Exists(string email);
}