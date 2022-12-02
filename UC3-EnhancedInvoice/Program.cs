using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UC3_EnhancedInvoice
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
        public double CalculateFare(MultipleRides[] ride)
        {   
            double totalfare = 0;
            foreach (MultipleRides rides in ride)
            {
                totalfare = totalfare + CalculateFare(rides.Distance, rides.Time);
            }
            return totalfare;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            InvoiceGenerator uc3 = new InvoiceGenerator();
            MultipleRides[] ride = { new MultipleRides(10, 15), new MultipleRides(15, 25) };
            double totalFare = uc3.CalculateFare(ride);
            int numOfRides = uc3.count;
            double avg = totalFare / numOfRides;
            Console.WriteLine("************** Invoice **************");
            Console.WriteLine($"Total Number of rides :  {numOfRides}");
            Console.WriteLine($"Aggregate fare is :  {totalFare}");
            Console.WriteLine($"Average Fare Per Ride : {avg}");
            Console.ReadLine();
        }
    }
}
