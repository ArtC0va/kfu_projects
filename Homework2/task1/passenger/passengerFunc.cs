namespace Homework2.passenger
{
    public static class PassengerFunc {
        public static void PrintOnScreen(Passenger passenger)
        {
            Console.WriteLine($"Full Name - {passenger.FullName}\nDate of Travel - {passenger.DateOfTravel.ToShortDateString()} \t Time of Travel - {passenger.TimeOfTravel}\nTrain ID - {passenger.TrainId} \tType of Railcar - {passenger.RailcarType} \tTicket Price - {passenger.TicketPrice}");
        }

        public static T GetInfo<T>(string message, Func<string?, (bool isTrue, T value)> parseFunc)
        {
            while (true)
            {
                Console.WriteLine(message);
                string? input = Console.ReadLine();
                var result = parseFunc(input);
                if (result.isTrue)
                    return result.value;
                else
                    Console.WriteLine("This is not the right information");
            }
        }
        public static (string?, int, DateTime, TimeOnly, TypeOfRailcar, float) ToPassenger(this Passenger passenger)
        {
            return (passenger.FullName, passenger.TrainId, passenger.DateOfTravel, passenger.TimeOfTravel, passenger.RailcarType, passenger.TicketPrice);
        }

        public static string? EnterInfo(string? message)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            return input;

        }
    }
}