namespace DefaultNamespace;

public class Laptop : Equipment
{
    public string OperationSystem { get; private set; }
    public int RAM { get; private set; }

    public Laptop(string name, bool status, string operationSystem, int ram) : base(name, status)
    {
        OperationSystem = operationSystem;
        RAM = ram;
    }
}