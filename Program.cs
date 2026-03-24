using System;
using DefaultNamespace;

class Program
{
	static void Main(String[] args)
	{

        IEquipmentService equipmentService = new EquipmentService();
        IUserService userService = new UserService();
        IRentalService rentalService = new RentalService();

        var laptop = new Laptop("Dell XPS 15", true, "Windows 11", 16);
        var projector = new Projector("Epson X", true, "Epson", "1080p");
        var camera = new Camera("Sony A7", true, 64, 8);
        
        equipmentService.AddEquipment(laptop);
        equipmentService.AddEquipment(projector);
        equipmentService.AddEquipment(camera);

        var studentJan = new Student("Jan", "Kowalski");
        var pracownikAnna = new Employee("Anna", "Nowak");
        
        userService.AddUser(studentJan);
        userService.AddUser(pracownikAnna);

        Console.WriteLine("Wypożyczenie sprzętu");
        var rental1 = rentalService.RentEquipment(studentJan, laptop, 3);
        
        var availableEquipment = equipmentService.GetAvailableEquipment();
        Console.WriteLine($"\nDostępny sprzęt w systemie: {availableEquipment.Count}");
        foreach (var eq in availableEquipment)
        {
            Console.WriteLine($"- {eq.Name} (Status: {eq.Status})");
        }

        Console.WriteLine("\nAktywne wypożyczenia Jana");
        var janRentals = rentalService.GetActiveRentals(studentJan);
        foreach (var r in janRentals)
        {
            Console.WriteLine($"- {r.RentedEquipment.Name}, Termin zwrotu: {r.DueDate.ToShortDateString()}");
        }

        Console.WriteLine("\nZwrot po terminie (Kara)");
        DateTime opoznionaDataZwrotu = rental1.RentDate.AddDays(5); 
        rentalService.ReturnEquipment(rental1, opoznionaDataZwrotu);

        Console.WriteLine("\nPrzeterminowane wypożyczenia");
        var rental2 = rentalService.RentEquipment(pracownikAnna, projector, 1);
        
        DateTime dzisiejszaDataSymulowana = rental2.RentDate.AddDays(4);
        var overdueRentals = rentalService.GetOverdueRentals(dzisiejszaDataSymulowana);
        
        Console.WriteLine($"Liczba przeterminowanych sprzętów: {overdueRentals.Count}");
        foreach (var r in overdueRentals)
        {
            Console.WriteLine($"- Kto przetrzymuje: {r.RentedBy.FirstName} {r.RentedBy.LastName}, Co: {r.RentedEquipment.Name}");
        }
		
		Console.WriteLine("\nTestowanie blokad biznesowych");
		Console.WriteLine("Próba wypożyczenia niedostępnego sprzętu:");
		var failedRental = rentalService.RentEquipment(studentJan, projector, 2);
	}
}