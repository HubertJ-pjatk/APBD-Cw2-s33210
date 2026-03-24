namespace DefaultNamespace;

public class EquipmentService : IEquipmentService
{
    private readonly List<Equipment> equipmentList = new List<Equipment>();

    public void AddEquipment(Equipment equipment)
    {
        equipmentList.Add(equipment);
    }

    public List<Equipment> GetAllEquipment()
    {
        return equipmentList;
    }
    
    public List<Equipment> GetAvailableEquipment()
    {
        List<Equipment> availableEquipment = new List<Equipment>();
        foreach (Equipment eq in equipmentList)
        {
            if (eq.Status == true)
            {
                availableEquipment.Add(eq);
            }
        }
        return availableEquipment;
    }
}