namespace Restaurant2._0
{
    public interface IBooking
    {
        void RegisterBooking(string customerName, DateTime date, int tableNumber);
        void CancelBooking(DateTime reservationDate);
    }
}
