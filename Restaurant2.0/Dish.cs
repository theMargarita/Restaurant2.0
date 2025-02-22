namespace Restaurant2._0
{
    public class Dish
    {
        private static int _number = 1;
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public List<string> Ingredients;


        public Dish(string name, decimal price, List<string> ingredients)
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;

            ID = _number;
            _number++;
        }
    }
}
