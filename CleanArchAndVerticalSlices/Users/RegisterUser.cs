namespace CleanArchAndVerticalSlices.Users;

public sealed class RegisterUser(IUserRepository userRepository)
{
    public record Request(string Email, string FirstName, string LastName, string Password);
    
    public async Task<User> Handle(Request request)
    {
        // Creating a user
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PasswordHash = "??"
        };
        // Storing in DB
        await userRepository.Insert(user);
        
        return user;
    }
}

// Clean Architecture Principles
// When we need to interact with an external facing service (databse, email service, file system, etc)
// we need to define a respective abstraction
public interface IUserRepository
{
    Task Insert(User user);
}

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}