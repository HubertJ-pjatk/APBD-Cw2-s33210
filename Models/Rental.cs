namespace DefaultNamespace;

public class Rental
{
    public Guid Id { get; private set; }
    public User RentedBy { get; private set; }
    public Equipment RentedEquipment { get; private set; }
    public DateTime RentDate { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }
    public int PenaltyFee { get; private set; }

    public Rental(User rentedby, Equipment rentedEquipment, int daysToRent)
    {
        Id = Guid.NewGuid();
        RentedBy = rentedby;
        RentedEquipment = rentedEquipment;
        RentDate = DateTime.Now;
        DueDate = RentDate.AddDays(daysToRent); 
        ReturnDate = null; 
        PenaltyFee = 0;
    }

    public void MarkAsReturned(DateTime returnDate, int penaltyFee)
    {
        ReturnDate = returnDate;
        PenaltyFee = penaltyFee;
    }
}