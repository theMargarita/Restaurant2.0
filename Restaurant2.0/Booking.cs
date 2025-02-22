namespace Restaurant2._0
{
    public class Booking //: IBooking
    {
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public Table Tables { get; set; }

        public Booking(DateTime reservationDate, string customerName, Table table)
        {
            ReservationDate = reservationDate;
            CustomerName = customerName;
            Tables = table;
        }
    }
}
