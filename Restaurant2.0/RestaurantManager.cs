namespace Restaurant2._0
{
    class RestaurantManager
    {
        public List<Table> Tables { get; set; } = new();
        public List<Booking> Bookings { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
      
        public Menu Menu = new Menu(); //new object of menu 


        public void AddTable(Table table) => Tables.Add(table);
        public void ShowTables()
        {
            Console.WriteLine("\nTables");
            foreach (var t in Tables)
            {
                string status = t.BookedDate.Any() ? "Booked" : "Available";
                Console.WriteLine($"{t.TableNumber}: {status}");
            }
        }
          
        public void MakeReservation(string customerName, DateTime date, int tableNumber)
        {

            Table? table = Tables.FirstOrDefault(t => t.TableNumber == tableNumber); //? = if null or not

            if (table == null)
            {
                Console.WriteLine($"Table {tableNumber} does not exists");
                return;
            }

            if (!table.CheckAvailability(date))
            {
                Console.WriteLine($"Table {tableNumber} is aleady booked on {date}");
                return;
            }

            //creates a new booking object within the parameters
            var booking = new Booking(date, customerName, table);
            Bookings.Add(booking);
            Console.WriteLine($"Table {table.TableNumber} reserved for {customerName} on {date}");


            //Console.WriteLine("Confirmed");
        }
        public void ShowBookings()
        {
            if (Bookings.Count == 0)
            {
                Console.WriteLine("No booking available");
                return;
            }

            Console.WriteLine("Currenct reservations\n");
            foreach (var b in Bookings.OrderBy(b => b.ReservationDate).ToList())
            {
                Console.WriteLine($"{b.CustomerName} - {b.ReservationDate} at table {b.Tables.TableNumber}");
            }
        }

        
        
        public void ConfirmOrder(int tableNumber, List<Dish> dishes)
        {
            Booking? booking = Bookings.FirstOrDefault(t => t.Tables.TableNumber == tableNumber);
            if (booking == null)
            {
                Console.WriteLine($"No booking found for {booking.CustomerName} at Table {tableNumber}");
                return;
            }

            Order order = Orders.FirstOrDefault(o => o.Tables.TableNumber == tableNumber);
            if(order == null)
            {
                order = new Order(booking.Tables);
                Orders.Add(order);
            }

            foreach (var d in dishes)
            {
                order.PlaceOrder(d, tableNumber);
            }
            Console.WriteLine($"\nOrder {order.OrderID} confirmed at Table " +
                $"{tableNumber}.\nTotal: {order.CalculateTotal():C}");
        }

        //incase you want to remove reservation
        public void RemoveReservation(string customerName)
        {
            var bookingToRemove = Bookings.FirstOrDefault(b => b.CustomerName == customerName);

            Bookings.Remove(bookingToRemove);
            Console.WriteLine($"Reservation for {customerName} has been removed");
        }

    }
}
