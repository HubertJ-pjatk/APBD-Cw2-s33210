using System;
using System.Collections.Generic;

namespace DefaultNamespace;

public class RentalService : IRentalService
{
    private readonly List<Rental> rentalsList = new List<Rental>();

    public Rental RentEquipment(User user, Equipment equipment, int daysToRent)
    {
        if (equipment.Status == false)
        {
            Console.WriteLine("Błąd: Sprzęt jest już wypożyczony.");
            return null;
        }
        
        List<Rental> activeRentals = GetActiveRentals(user);
        
        if (activeRentals.Count >= user.MaxRentals)
        {
            Console.WriteLine($"Błąd: Użytkownik osiągnął limit wypożyczeń ({user.MaxRentals}).");
            return null;
        }
        
        Rental newRental = new Rental(user, equipment, daysToRent);
        rentalsList.Add(newRental);
        equipment.UpdateStatusToFalse();

        Console.WriteLine($"Sukces: Wypożyczono {equipment.Name} dla {user.FirstName}.");
        return newRental;
    }

    public List<Rental> GetActiveRentals(User user)
    {
        List<Rental> active = new List<Rental>();
        foreach (Rental r in rentalsList)
        {
            if (r.RentedBy.Id == user.Id && r.ReturnDate == null)
            {
                active.Add(r);
            }
        }
        return active;
    }

    public List<Rental> GetOverdueRentals(DateTime currentDate)
    {
        List<Rental> overdue = new List<Rental>();
        foreach (Rental r in rentalsList)
        {
            if (r.ReturnDate == null && r.DueDate < currentDate)
            {
                overdue.Add(r);
            }
        }
        return overdue;
    }

    public void ReturnEquipment(Rental rental, DateTime returnDate)
    {
        if (rental.ReturnDate != null)
        {
            Console.WriteLine("Błąd: Ten sprzęt został już zwrócony.");
            return;
        }
        
        int penaltyFee = 0;
        
        if (returnDate > rental.DueDate)
        {
            TimeSpan delay = returnDate - rental.DueDate;
            
            int daysLate = (int)delay.TotalDays;
            
            penaltyFee = daysLate * 10; 
        }
        
        rental.MarkAsReturned(returnDate, penaltyFee);
        rental.RentedEquipment.UpdateStatusToTrue();
        Console.WriteLine($"Sukces: Zwrócono sprzęt. Naliczona kara: {penaltyFee} PLN.");
    }
}