using System.Collections.Generic;

namespace DefaultNamespace;

public interface IEquipmentService
{
    void AddEquipment(Equipment equipment);
    List<Equipment> GetAllEquipment();
    List<Equipment> GetAvailableEquipment();
}