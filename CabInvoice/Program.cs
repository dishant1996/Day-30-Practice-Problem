using System;
using System.Collections.Generic;

namespace CabInvoice
{
    public class MultipleRides
    {
        public double Distance;
        public int Time;
        public MultipleRides(double Distance, int Time)
        {
            this.Time = Time;
            this.Distance = Distance;
        }
    }
    public class InvoiceGenerator
    {
        public double CostPerKm = 10;
        public int CostPerMinute = 1;
        public int MinimumFare = 5;
        public int count;
        //UC1
        public double CalculateFare(double Distance, int Time)
        {
            count++;
            double Fare = (CostPerKm * Distance) + (CostPerMinute * Time);
            return Math.Max(Fare, MinimumFare);
        }
        //UC2
        public double CalculateFare(MultipleRides[] ride, string RideType)
        {
            if (RideType == "Normal")
            {
                CostPerKm = 10;
                CostPerMinute = 1;
                MinimumFare = 5;
            }
            else if (RideType == "Premium")
            {
                CostPerKm = 15;
                CostPerMinute = 2;
                MinimumFare = 20;
            }
            double totalfare = 0;
            foreach (MultipleRides rides in ride)
            {
                totalfare = totalfare + CalculateFare(rides.Distance, rides.Time);

            }
            return totalfare;
        }
        //UC3
        public void InvoiceSummary(MultipleRides[] ride, string RideType)
        {

            foreach (MultipleRides rides in ride)
            {
                Console.WriteLine("Ride Type :" + RideType);
                Console.WriteLine("Distance Travelled :" + rides.Distance);
                Console.WriteLine("Time Taken :" + rides.Time);
                Console.WriteLine("Fare for ride is :" + CalculateFare(rides.Distance, rides.Time));
            }
        }
    }
    //UC4
    public class RideRepository
    {
        Dictionary<string, MultipleRides[]> DictionaryOfRideDetails = new Dictionary<string, MultipleRides[]>();
        public RideRepository()
        {
            this.DictionaryOfRideDetails = new Dictionary<string, MultipleRides[]>();
        }
        public void AddRides(string userId, MultipleRides[] rides)
        {
            if (!DictionaryOfRideDetails.ContainsKey(userId))
            {
                DictionaryOfRideDetails.Add(userId, rides);
            }
            else
            {
                Console.WriteLine("Rides are Null");
            }
        }
        public MultipleRides[] GetRide(string userId)
        {
            foreach (var data in DictionaryOfRideDetails)
            {
                if (data.Key == userId)
                {
                    Console.WriteLine("User ID is :" + userId);
                    return data.Value;
                }
                else
                {
                    Console.WriteLine("Invalid User ID");
                }
            }
            return null;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To CabIn voice Genrater");
            InvoiceGenerator Data = new InvoiceGenerator();
            while (true)
            {
                Console.WriteLine("Choose the Option below");
                Console.WriteLine("1)calculatefare\n2)Calculate Multiple Ride\n3)Ehanced Invoice\n4)Invoice Service\n");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        InvoiceGenerator uc1 = new InvoiceGenerator();
                        double fare1 = uc1.CalculateFare(10, 30);
                        Console.WriteLine("Total Fare for your Journey is :" + fare1);
                        break;
                    case 2:
                        InvoiceGenerator uc2 = new InvoiceGenerator();
                        MultipleRides[] rides = { new MultipleRides(10, 20), new MultipleRides(15, 25) };
                        double totalfare = uc2.CalculateFare(rides, "Normal");
                        Console.WriteLine("Aggregate fare Value is :" + totalfare);
                        break;
                    case 3:
                        InvoiceGenerator uc3 = new InvoiceGenerator();
                        MultipleRides[] rides1 = { new MultipleRides(10, 20), new MultipleRides(15, 25) };
                        double totalFare = uc3.CalculateFare(rides1, "Normal");
                        int numOfRides = uc3.count;
                        double avg = totalFare / numOfRides;
                        Console.WriteLine("************** Invoice **************");
                        Console.WriteLine($"Total Number of rides :  {numOfRides}");
                        Console.WriteLine($"Aggregate fare is :  {totalFare}");
                        Console.WriteLine($"Average of all the rides : {avg}");
                        Console.WriteLine("-------------------------------------");
                        break;

                    case 4:
                        InvoiceGenerator uc4 = new InvoiceGenerator();
                        Console.WriteLine("Please enter the user id :");
                        string UserId = Console.ReadLine();
                        MultipleRides[] rides2 = { new MultipleRides(10, 20), new MultipleRides(15, 25) };
                        double totalFare1 = uc4.CalculateFare(rides2, "Normal");
                        int numOfRides1 = uc4.count;
                        double avg1 = totalFare1 / numOfRides1;

                        RideRepository r1 = new RideRepository();
                        r1.AddRides(UserId, rides2);
                        Console.WriteLine("************** Invoice **************");
                        MultipleRides[] ride3 = r1.GetRide(UserId);
                        Console.WriteLine("Total Number of rides : " + numOfRides1);
                        uc4.InvoiceSummary(rides2, "Normal");
                        Console.WriteLine("Aggregate fare is :" + totalFare1);
                        Console.WriteLine("Average of all the rides :" + avg1);
                        Console.WriteLine("-------------------------------------");
                        break;

                    default:
                        Console.WriteLine("Choose the below option");
                        break;
                        Console.ReadLine();
                }
            }
        }
    }
}
