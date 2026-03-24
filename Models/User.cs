namespace DefaultNamespace;

public abstract class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public abstract string Role { get; }
    public abstract int MaxRentals { get; }

    public User(string firstName, string lastName)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
    }
}