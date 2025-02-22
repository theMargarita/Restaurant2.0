namespace Restaurant2._0
{
    public class Order : IOrderable
    {
        private static int _orderCounter = 1;
        public int OrderID { get; set; }
        public List<Dish> Dishes { get; set; } = new();
        public Table Tables { get; set; }

        public Order(Table table)
        {
            OrderID = _orderCounter;
            _orderCounter++;
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
