namespace Restaurant2._0
{
    public class Order : IOrderable
    {
        private static int _orderCounter = 1;
        public int OrderID { get; set; }
        public List<Dish> Dishes { get; set; } = new(); //list with dish objects from class dish (would be null if if initialized)
        public Table Tables { get; set; } //an object that can be accessed from outside

        public Order(Table table)
        {
            OrderID = _orderCounter;
            _orderCounter++; //increment for every dish with own id
            Tables = table; 
        }

        public void PlaceOrder(Dish dish, int tableNumber)
        {
            Dishes.Add(dish);
            Console.WriteLine($"Order: {OrderID} Added {dish.Name} at table {Tables.TableNumber}");
        }
        public decimal CalculateTotal()
        {
            return Dishes.Sum(d => d.Price);
        }
    }
}
