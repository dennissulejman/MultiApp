using System;
using System.Text.RegularExpressions;


namespace MultiApp
{
    class Program
    {
        
        static void Main(string[] args)
        {            
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        }
        
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome! Type one of the options to do the following:");
            Console.WriteLine("1: Try your luck, roll the die!");
            Console.WriteLine("2: Write lists of your things and print them.");
            Console.WriteLine("3: Check out version 2.0 of my calculator.");
            Console.WriteLine();
            Console.WriteLine("Type 4 then press enter to close the application.");
            string result = Console.ReadLine();
            if (result == "1")
            {
                NumbersGame();
                return true;
            }
            else if (result == "2")
            {
                Lists();
                return true;
            }
            else if (result == "3")
            {
                Calculator();
                return true;
            }
            else if (result == "4")
            {
                Console.WriteLine("Exiting the application...");
                Console.ReadLine();
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void NumbersGame()
        {
            Console.Clear();
            Console.WriteLine("To win, you will need either 5 or 6.");
            Console.WriteLine("Press enter to roll the die!");
            Console.ReadKey(true);
            bool run = true;
            Random rand = new Random();
            int tries = 0;                     
            

            while (run)
            {
                int die = rand.Next(1, 7);                
                tries++;
                if (die < 5)
                {
                    Console.WriteLine("{0}, Try again!", die);
                    Console.ReadLine();
                }
                else if (die >= 5)
                {
                    Console.WriteLine("{0}! You won after {1} die rolls.", die, tries);
                    Console.ReadLine();
                    run = false;
                }                
            }           
        }
        
        private static bool Lists()
        {
            Console.Clear();
            Console.WriteLine("Choose what you would like to sort:");
            Console.WriteLine("1: Books.");
            Console.WriteLine("2: Cars.");
            Console.WriteLine("3: Board Games.");
            string result = Console.ReadLine();

            if (result == "1")
            {
                Book.ListMethod();               
                return true;
            }
            else if (result == "2")
            {
                Car.ListMethod();
                return true;
            }
            else if (result == "3")
            {
                BoardGame.ListMethod();
                return true;
            }
            else
            {
                return false;
            }
        }
        private static void Calculator()
        {
            Console.Clear();
            Console.WriteLine("Write a mathematical problem using +, -, * or /");
            string expression = Console.ReadLine();
            string pattern = @"(\d*(?:.\d{1,*})?)\s*([-+*/])\s*(\d*(?:.\d{1,*})?)";
            foreach (Match m in Regex.Matches(expression, pattern))
            {
                decimal value1 = decimal.Parse(m.Groups[1].Value);
                decimal value2 = decimal.Parse(m.Groups[3].Value);
                switch (m.Groups[2].Value)
                {
                    case "+":
                        Console.WriteLine("{0} = {1:N2}", m.Value, value1 + value2);
                        break;
                    case "-":
                        Console.WriteLine("{0} = {1:N2}", m.Value, value1 - value2);
                        break;
                    case "*":
                        Console.WriteLine("{0} = {1:N2}", m.Value, value1 * value2);
                        break;
                    case "/":
                        Console.WriteLine("{0} = {1:N2}", m.Value, value1 / value2);
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}
