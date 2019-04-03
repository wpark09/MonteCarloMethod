using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloMethod
{
    public struct Coordinates
    {
        double x;
        double y;

        public Coordinates(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Coordinates(Random randomValue)
        {
            this.x = randomValue.NextDouble();
            this.y = randomValue.NextDouble();
        }

        public double Hypotenuse(Coordinates coordsXY)
        {
            double hypotenuse = Math.Sqrt(Math.Pow(coordsXY.x, 2) + Math.Pow(coordsXY.y, 2));
            return hypotenuse;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;

            do
            {
                try
                {
                    Console.WriteLine("Enter the number of iterations (Enter -1 to quit): ");
                    int iteration = int.Parse(Console.ReadLine());

                    if (iteration == -1)
                    {
                        quit = true;
                    }

                    Random randomValue = new Random();
                    bool[] coordsArray = new bool[iteration];

                    for (int i = 0; i < coordsArray.Length; ++i)
                    {

                    Coordinates coords = new Coordinates(randomValue);
                        double hypotenuse = coords.Hypotenuse(coords);
                        if (hypotenuse <= 1)
                        {
                            coordsArray[i] = true;
                        }
                        else coordsArray[i] = false;
                    }

                    double averageRadius = 4 * (AddArrayValues(coordsArray) / coordsArray.Length);
                    Console.WriteLine($"Value: {averageRadius}" +
                        $"\nValue of Pi: {Math.PI}" +
                        $"\nDifference: {Math.Abs(Math.PI - averageRadius)}\n");
                }
                catch (OverflowException)
                { Console.WriteLine("You entered an invalid value.\n"); }
                catch (OutOfMemoryException)
                { Console.WriteLine("You entered a value that is too large.\n"); }
                catch(FormatException)
                { Console.WriteLine("Enter a positive integer.\n"); }

            } while (!quit);
        }

        private static double AddArrayValues(bool[] arrayDouble)
        {
            double sumValue = 0;
            foreach (var item in arrayDouble)
            {
                if (item == true)
                    sumValue++; 
            }
            return sumValue;
        }
    }
}
