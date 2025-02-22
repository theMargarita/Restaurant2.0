namespace Restaurant2._0
{
    public class Table
    {
        public int TableNumber { get; set; }
        public List<DateTime> BookedDate { get; set; }

        public Table(int tableNumber)
        {
            TableNumber = tableNumber;
            BookedDate = new List<DateTime>();
            //Status = false;
        }

        public bool CheckAvailability(DateTime date)
        {
            return !BookedDate.Contains(date);
        }
    }
}
