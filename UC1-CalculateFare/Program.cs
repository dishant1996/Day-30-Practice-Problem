using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UC1_CalculateFare
{
    public class Fare
    {
        public double CostPerKm = 10;
        public int CostPerMinute = 1;
        public int MinimumFare = 5;
        public double CalculateFare(double Distance, int Time)
        {
            double Fare = (CostPerKm * Distance) + (CostPerMinute * Time);
            return Math.Max(Fare, MinimumFare);
        }
    }
   internal class main
   {
        static void Main(string[] args)
        {
          Fare uc1 = new Fare();
          double fare1 = uc1.CalculateFare(10, 30);
          Console.WriteLine($"Total Fare for your Journey is :{fare1}");
          Console.ReadLine();
        }
    }
}
