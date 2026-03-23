namespace DefaultNamespace;

public class Camera : Equipment
{
    public int Memory { get; private set; }
    public int RAM { get; private set; }

    public Camera(string name, bool status, int memory, int ram) : base(name, status)
    {
        Memory = memory;
        RAM = ram;
    }
}