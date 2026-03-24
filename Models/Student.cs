namespace DefaultNamespace;

public class Student : User
{
    public override string Role => "Student";
    public override int MaxRentals => 2;

    public Student(string firstName, string lastName) : base(firstName, lastName)
    {
        
    }
}