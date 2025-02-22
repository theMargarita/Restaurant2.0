namespace Restaurant2._0
{
    public interface IOrderable
    {
        void PlaceOrder(Dish dish, int tableNumber);
        decimal CalculateTotal();
    }
}
