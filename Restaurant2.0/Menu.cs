using System.Linq;

namespace Restaurant2._0
{
    public class Menu
    {
        public List<Dish> Dishes { get; set; } = new();

        public void AddDish(Dish dish)
        {
            Dishes.Add(dish);
        }

        public void RemoveDish(int dishId)
        {
            Dishes.RemoveAll(d => d.ID == dishId);
            Console.WriteLine($"Dish {dishId} removed");
        }
        
        public void ShowMenu()
        {

            Console.WriteLine("The menu: ");
            foreach(var d in Dishes)
            {
                Console.WriteLine($"{d.ID}: {d.Name} {d.Price} | Ingrdients: {string.Join(", ", d.Ingredients)}");
            }
        }

        public void UpdateDish(int dishId, string newDish, decimal newPrice, List<string> newIngredients)
        {
            var dish = Dishes.FirstOrDefault(d => d.ID == dishId);
            if (dish == null)
            {
                Console.WriteLine("Dish not found");
                return;
            }
            dish.Name = newDish; //new dishname
            dish.Price = newPrice;
            dish.Ingredients = newIngredients;
            Console.WriteLine($"ID: {dish.ID} Updated to {newDish} - {newPrice:C}");
        }

        public void AddIngredients(int dishId, string ingredients)
        {
            Dish dish = Dishes.FirstOrDefault(d => d.ID == dishId);
            if (dish == null )
            {
                Console.WriteLine("Dish is not found in the menu.");
                return;
            }
            if (dish.Ingredients.Contains(ingredients))
            {
                Console.WriteLine($"Ingredient '{ingredients}' is already in '{dish.Name}'.");
                return;
            }

            dish.Ingredients.Add(ingredients);
            Console.WriteLine($"Ingredient {ingredients} added in {dish.Name}");
        }


        //public void RemoveIngredient(string ingredients, int dishId)
        //{
        //    Dish dish = Dishes.FirstOrDefault(d => d.ID == dishId);
        //    if (dish == null)
        //    {
        //        Console.WriteLine("Dish not found");
        //        return;
        //    }
        //    if (!dish.Ingredients.Contains(ingredients))
        //    {
        //        Console.WriteLine($"Ingredient {ingredients} is not in {dish.Name}."); 
        //        return;
        //    }
        //    dish.Ingredients.Remove(ingredients);
        //    Console.WriteLine("Ingredient removed");
        //}
    }
}
