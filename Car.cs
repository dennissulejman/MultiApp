using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MultiApp
{
    internal class Car
    {
        public string CarMake { get; set; }

        public string CarModel { get; set; }

        public string CarColor { get; set; }

        public int CarYear { get; set; }

        public override string ToString()
        {
            return "Make: " + CarMake + "Model: " + CarModel + "Color: " + CarColor + "Year: " + CarYear;
        }

        public static void ListMethod()
        {
            List<Car> myCars = new List<Car>();
            Console.Clear();
            bool newCar = true;
            while (newCar)
            {
                Console.WriteLine("What is the make of your car?");
                string make = Console.ReadLine();
                Console.WriteLine("What is the model of your car?");
                string model = Console.ReadLine();
                Console.WriteLine("What color is your car?");
                string color = Console.ReadLine();
                Console.WriteLine("What year was your car made?");
                int year = int.Parse(Console.ReadLine());

                myCars.Add(new Car()
                { 
                    CarMake = make + ", ", 
                    CarModel = model + ", ", 
                    CarColor = color + ", ", 
                    CarYear = year
                });

                Console.WriteLine("Add another car?(Y/N)");
                string response = Console.ReadLine();
                if (response == "y")
                {
                    newCar = true;
                }
                else if (response == "n")
                {
                    newCar = false;
                    Console.WriteLine("These are the cars in your collection:");
                    Console.WriteLine();
                    StringBuilder Cars = new StringBuilder();
                    Cars.AppendLine("My Collection of Cars:");
                    Cars.AppendLine();
                    foreach (Car aCar in myCars)
                    {
                        Cars.AppendLine(aCar.ToString());

                    }
                    Console.WriteLine(Cars.ToString());
                    {
                        Console.WriteLine("Would you like to print your collection of cars to a file?(Y/N)");
                        string print = (Console.ReadLine());
                        if (print == "y")
                        {

                            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
                                + @"\CarCollection.txt", Cars.ToString());
                            Console.WriteLine("Your collection was printed successfully!");
                            Console.ReadLine();
                            newCar = false;
                        }
                        else if (print != "y")
                        {
                            newCar = false;
                        }
                    }
                }
            }
        }
    }
}
