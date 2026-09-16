using System;
using Homework2.spaceman;
using Homework2.passenger;
using Homework2.rentalCar;
using Homework2.student;

namespace Homework2 
{
    class Program
    {
        static void Main()
        {
            //task 0
            byte oxygenLevel = 250;
            byte extraOxygen = 10;

            byte result = (byte)(oxygenLevel + extraOxygen);
            int intRes = oxygenLevel + extraOxygen;
            Console.WriteLine("OxygenLevel - {0}, \n ExtraOxygen - {1}, \n Result - {2}, \n Int(oxygenLevel + extraOxygen) - {3}", oxygenLevel, extraOxygen, result, intRes);

            //task 1
            Spaceman person0 = new Spaceman()
            {
                Name = SpacemanFunc.EnterInfo("Enter name"),
                Age = SpacemanFunc.GetInfo<byte>("Enter age",s => (byte.TryParse(s, out byte val), val)),
                Height = SpacemanFunc.GetInfo<float>("Enter height", s => (float.TryParse(s, out float val), val)),
                Weight = SpacemanFunc.GetInfo<float>("Enter weight", s => (float.TryParse(s, out float val), val)),
                FavoriteFilmAboutSpace = SpacemanFunc.EnterInfo("Enter favorite film about Space")
            };
            SpacemanFunc.PrintOnScreen(person0);

            // task 2
            List<(string? fullName, int trainId, DateTime dateOfTravel, TimeOnly timeOfTravel, TypeOfRailcar railcarType, float ticketPrice)> passengerList = new();

            Passenger passenger1 = new Passenger
            {
                FullName = PassengerFunc.EnterInfo("Enter full name"),
                TrainId = PassengerFunc.GetInfo<int>("Enter train ID", s => (int.TryParse(s, out int val), val)),
                DateOfTravel = PassengerFunc.GetInfo<DateTime>("Enter date of travel", s => (DateTime.TryParse(s, out DateTime val), val)),
                TimeOfTravel = PassengerFunc.GetInfo<TimeOnly>("Enter time of travel", s => (TimeOnly.TryParse(s, out TimeOnly result), result)),
                RailcarType = PassengerFunc.GetInfo<TypeOfRailcar>("Enter type of railcar (0 - CouchetteCar, 1 - CompartmentCar, 2 - SleeperCar, 3 - LuxuryCar)", s => (Enum.TryParse<TypeOfRailcar>(s, out TypeOfRailcar val), val)),
                TicketPrice = PassengerFunc.GetInfo<float>("Enter ticket price", s => (float.TryParse(s, out float val), val))
            };
            PassengerFunc.PrintOnScreen(passenger1);
            passengerList.Add(passenger1.ToPassenger());        
            
            //task 3
            List<(string? name, string? brang, Class classOfCar, DateOnly start, DateOnly end, float price)> rentalCarList = new();

            Console.WriteLine("Enter data about person and car: name, brend, class, start date, end date, price by day. \nName and Brand");
            RentalCar person1 = new RentalCar
            {
                Name = RentalCarFunc.EnterInfo("Enter name"),
                Brand = RentalCarFunc.EnterInfo("Enter brand"),
                ClassOfCar = RentalCarFunc.GetInfo<Class>("Enter vehile class of car (0 - economy, 1 - comfort, 2 - bisiness, 3 - premium)", s => (Enum.TryParse<Class>(s, out Class result), result)),
                StartDate = RentalCarFunc.GetInfo<DateOnly>("Lease start date", s => (DateOnly.TryParse(s, out DateOnly res), res)),
                EndDate = RentalCarFunc.GetInfo<DateOnly>("Lease end date", s => (DateOnly.TryParse(s, out DateOnly res), res)),
                Price = RentalCarFunc.GetInfo<float>("Daily rental rate", s => (float.TryParse(s, out float res), res))
            };
            rentalCarList.Add(person1.ToRentalCar());
            RentalCarFunc.PrintOnScreen(person1);

            //task 4
            List<(string? fullName, string? id, Direction speciality, byte level, float middleMark, DateOnly date)> studentList = new();

            Student student1 = new Student
            {
                FullName = StudentFunc.EnterInfo("Enter full name"),
                Id = StudentFunc.EnterInfo("Enter student's id"),
                Speciality = StudentFunc.GetInfo<Direction>("Enter your speciality(0 - it, 1 - economy, 2 - jory, 3 - design)", s => (Direction.TryParse(s, out Direction result), result)),
                Level = StudentFunc.GetInfo<byte>("Enter your level", s => (byte.TryParse(s, out byte result), result)),
                MiddleMark = StudentFunc.GetInfo<float>("Enter middle mark", s => (float.TryParse(s, out float result), result)),
                StartDate = StudentFunc.GetInfo<DateOnly>("Enter start date", s => (DateOnly.TryParse(s, out DateOnly result), result))
            };
            studentList.Add(student1.ToStudent());
            StudentFunc.PrintOnScreen(student1);
        }
    }
}