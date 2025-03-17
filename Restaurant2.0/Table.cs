namespace Restaurant2._0
{
    public class Table(int tableNumber)
    {
        public int TableNumber { get; set; } = tableNumber; //primary constructor - according to vs

        public List<DateTime> BookedDate { get; set; } = new List<DateTime>(); //primary constructor - according to vs

        public bool CheckAvailability(DateTime date)
        {
            return !BookedDate.Contains(date);
        }
    }
}
