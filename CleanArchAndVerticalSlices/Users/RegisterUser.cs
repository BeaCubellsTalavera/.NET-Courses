namespace CleanArchAndVerticalSlices.Users;

public sealed class RegisterUser(IUserRepository userRepository, IPasswordHasher passwordHasher)
{
    public record Request(string Email, string FirstName, string LastName, string Password);
    
    public async Task<User> Handle(Request request)
    {
        // Race condition
        // Option 1: introduce a lock before beginning the handle method
        // Option 2: define a unique index inside of the DB and encapsulate the logic in the user repository
        if (await userRepository.Exists(request.Email))
        {
            throw new Exception("The email is already in use");
        }
        
        // Creating a user
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PasswordHash = passwordHasher.Hash(request.Password)
        };
        // Storing in DB
        await userRepository.Insert(user);
        
        // Email verification
        
        
        return user;
    }
}