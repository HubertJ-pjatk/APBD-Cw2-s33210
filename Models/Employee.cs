namespace DefaultNamespace;

public class Employee : User
{
    public override string Role => "Employee";
    public override int MaxRentals => 5;

    public Employee(string firstName, string lastName) : base(firstName, lastName)
    {
        
    }
}