namespace Restaurant2._0
{
    internal class Program
    {
        public static RestaurantManager m = new RestaurantManager();
        static void Main(string[] args)
        {
            TheMenu();
            Console.WriteLine();
            Console.ReadKey();

            Console.Clear();
            UpdateMenu();
            Console.WriteLine();
            Console.ReadKey();

            Console.Clear();
            Tables();
            Console.WriteLine();
            Console.ReadKey();

            Console.Clear();
            ReservationsList();
            Console.WriteLine();
            Console.ReadKey();

            Console.Clear();
            m.ShowBookings();
            Console.WriteLine();
            Console.ReadKey();

            Console.Clear();
            Orders();
            Console.WriteLine();
            Console.ReadKey();

            Console.Clear();
            ShowOrders();
            Console.ReadKey();

        }

        public static void TheMenu()
        {
            var dishes = new List<Dish>
            {
             new Dish("Misu Soup", 109.99m, new List<string> { "Tofu", "Sea weed" }),
             new Dish("Ramen Soup", 129.99m, new List<string> { "Noodles", "Ham", "Sea weed" }),
             new Dish("Shrimp soup", 149.99m, new List<string> { "Extra shrimp", "Butter" }),
             new Dish("Italian soup", 99.99m, new List<string> { "Bread", "Cream fráiche" }),
             new Dish("Borsh soup", 89.99m, new List<string> { "Russian yoghurt", "Bread" }),
             new Dish("Taco Soup", 110.00m, new List<string>{"Cream fraiche", "Cherry Tomatoes", "Some onion"}),
             new Dish("Carrot Soup", 89.99m, new List<string>{"Basil, Garlic Bread"})
            };

            foreach (var d in dishes)
            {
                m.Menu.AddDish(d);
            }
            m.Menu.ShowMenu();
        }
        public static void UpdateMenu()
        {
            m.Menu.AddIngredients(1, "Spring Onion");
            m.Menu.AddIngredients(2, "Pork");
            m.Menu.AddIngredients(3, "Chilli");

            m.Menu.UpdateDish(2, "Vegan Ramen", 119.99m, new List<string> { "Noodles", "Mushrooms", "Tofu" });

            m.Menu.RemoveDish(7);

            Console.WriteLine();
            m.Menu.ShowMenu();
            Console.WriteLine();
        }
        public static void Tables()
        {
            for (int i = 1; i < 7; i++)
            {
                m.AddTable(new Table(i));
            }
            m.ShowTables();
        }
        public static void ReservationsList()
        {

            m.MakeReservation("Fibie Meowmoew", new DateTime(2025, 3, 1, 18, 0, 0), 3);
            m.MakeReservation("Hermano Axelsas", new DateTime(2025, 3, 1, 18, 0, 0), 4);
            m.MakeReservation("Fibie MeowMeow", new DateTime(2025, 03, 02, 19, 0, 0), 1);
            m.MakeReservation("Margi Margo", new DateTime(2025, 03, 01, 18, 0, 0), 2);
            m.MakeReservation("Holly Huskisson", new DateTime(2025, 02, 28, 19, 30, 00), 1);
            m.MakeReservation("Herman Axelsson", new DateTime(2025, 02, 28, 19, 0, 0), 2);
            m.MakeReservation("Flower Power", new DateTime(2025, 3, 1, 19, 0, 0), 3);
            m.MakeReservation("Fibie MeowMeow", new DateTime(2025, 3, 3, 18, 30, 0), 4);
            m.MakeReservation("Holly Huskisson", new DateTime(2025, 03, 03, 19, 00, 00), 5);
            m.MakeReservation("Holly Polly", new DateTime(2025, 02, 28, 19, 30, 00), 7); //does not exists
            m.MakeReservation("Margi morgo", new DateTime(2025, 02, 24, 19, 30, 00), 6);
            m.MakeReservation("Bob Boddy", new DateTime(2025, 02, 24, 19, 30, 00), 2);
        }
        public static void Orders()
        {
            int tnumber = 6;
            Booking? booking = m.Bookings.FirstOrDefault(b => b.Tables.TableNumber == tnumber);
            if (booking != null)
            {
                List<Dish> orderDishes = new List<Dish>
                {
                    m.Menu.Dishes.FirstOrDefault(d => d.ID == 1),
                    m.Menu.Dishes.FirstOrDefault(d => d.ID == 2),
                    m.Menu.Dishes.FirstOrDefault(d => d.ID == 5),
                    m.Menu.Dishes.FirstOrDefault(d => d.ID == 4),

                };

                if (orderDishes.Count > 0)
                {
                    m.ConfirmOrder(booking.Tables.TableNumber, orderDishes);
                }
            }
            Console.WriteLine();
            int tn2 = 2;
            Booking? booking2 = m.Bookings.FirstOrDefault(b => b.Tables.TableNumber == tn2);
            if (booking2 != null)
            {
                List<Dish> orderDishes = new List<Dish>
                {
                    m.Menu.Dishes.FirstOrDefault(d => d.ID == 3),
                    m.Menu.Dishes.FirstOrDefault(d => d.ID == 3),
                    m.Menu.Dishes.FirstOrDefault(d => d.ID == 5),
                    m.Menu.Dishes.FirstOrDefault(d => d.ID == 4),
                    m.Menu.Dishes.FirstOrDefault(d => d.ID == 1),
                    m.Menu.Dishes.FirstOrDefault(d => d.ID == 6),


                };

                if (orderDishes.Count > 0)
                {
                    m.ConfirmOrder(booking2.Tables.TableNumber, orderDishes);
                }
            }
        }
        public static void ShowOrders()
        {
            Console.WriteLine("Orders");
            foreach (var o in m.Orders)
            {
                foreach (var d in m.Menu.Dishes)
                {
                    Console.WriteLine($"Table {o.Tables.TableNumber} dish {d.Name}");
                }
            }
                    Console.WriteLine();
        }

        //-----------
        //public static void RemoveReservations()
        //{
        //    Console.WriteLine("Enter the name of the customer");
        //    string name = Console.ReadLine();
        //    m.RemoveReservation(name);
        //}
        ////the interactive part - inte nödvändligt men den fungerar 
        //public static void MakeReservation()
        //{
        //    Console.WriteLine("Enter your name");
        //    string name = Console.ReadLine();

        //    DateTime date;
        //    while (true)
        //    {
        //        Console.WriteLine("Enter the date and time (YYYY-MM-DD HH:MM:SS)");
        //        if (DateTime.TryParse(Console.ReadLine(), out date))
        //        {
        //            break;
        //        }
        //        Console.WriteLine("Invalid typo, try again");
        //        return;
        //    }

        //    int table;
        //    while (true)
        //    {
        //        Console.WriteLine("Enter a table number, between 1-7");
        //        if (int.TryParse(Console.ReadLine(), out table) && table >= 1 && table <= 7)
        //        {
        //            break;
        //        }
        //        Console.WriteLine("Invalid or booked table");
        //        //return;
        //    }

        //    m.MakeReservation(name, date, table);
        //    //Console.WriteLine("Confirmed");
        //}

    }
}

