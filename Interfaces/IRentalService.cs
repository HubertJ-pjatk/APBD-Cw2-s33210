using System;
using System.Collections.Generic;

namespace DefaultNamespace;

public interface IRentalService
{
    Rental RentEquipment(User user, Equipment equipment, int daysToRent);
    
    void ReturnEquipment(Rental rental, DateTime returnDate);
    
    List<Rental> GetActiveRentals(User user);

    List<Rental> GetOverdueRentals(DateTime currentDate);
}