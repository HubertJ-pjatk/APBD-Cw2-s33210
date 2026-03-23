namespace DefaultNamespace;

public class Projector : Equipment
{
    public string Model { get; private set; }
    public string Resolution { get; private set; }
    
    public Projector(string name, bool status, string model, string resolution) : base(name, status)
    {
        Model = model;
        Resolution = resolution;
    }
}