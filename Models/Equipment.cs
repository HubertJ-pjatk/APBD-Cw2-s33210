namespace DefaultNamespace;

public abstract class Equipment
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public bool Status { get; private set; }

    public Equipment(string name, bool status)
    {
        Id = Guid.NewGuid();
        Name = name;
        Status = status;
    }

    public void UpdateStatusToTrue()
    {
        Status = true;
    }

    public void UpdateStatusToFalse()
    {
        Status = false;
    }
}