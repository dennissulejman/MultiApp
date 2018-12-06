using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiApp
{
    class BoardGame
    {
        public string BoardGameTitle { get; set; }

        public string BoardGameCategory { get; set; }

        public int BoardGameYear { get; set; }

        public override string ToString()
        {
            return "Title: " + BoardGameTitle + "Category: " 
                + BoardGameCategory + "Year: " + BoardGameYear;
        }
        public static void ListMethod()
        {
            List<BoardGame> myBoardGames = new List<BoardGame>();
            Console.Clear();
            bool newBoardGame = true;
            while (newBoardGame)
            {
                Console.WriteLine("What is the title of your game?");
                string title = Console.ReadLine();
                Console.WriteLine("What is the category of your game?");
                string category = Console.ReadLine();
                Console.WriteLine("What year was your game made?");
                int year = int.Parse(Console.ReadLine());

                myBoardGames.Add(new BoardGame()
                {
                    BoardGameTitle = title + ", ",
                    BoardGameCategory = category + ", ",
                    BoardGameYear = year
                });

                Console.WriteLine("Add another board game?(Y/N)");
                string response = Console.ReadLine();
                if (response == "y")
                {
                    newBoardGame = true;
                }
                else if (response == "n")
                {
                    newBoardGame = false;
                    Console.WriteLine("These are the board games in your collection:");
                    Console.WriteLine();
                    StringBuilder BoardGames = new StringBuilder();
                    BoardGames.AppendLine("My Collection of Board Games:");
                    BoardGames.AppendLine();
                    foreach (BoardGame aBoardGame in myBoardGames)
                    {
                        BoardGames.AppendLine(aBoardGame.ToString());
                    }
                    Console.WriteLine(BoardGames.ToString());
                    {
                        Console.WriteLine("Would you like to print your collection of board games to a file?(Y/N)");
                        string print = (Console.ReadLine());
                        if (print == "y")
                        {
                            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)                                
                                +@"\BoardGameCollection.txt", BoardGames.ToString());
                            Console.WriteLine("Your collection was printed successfully!");
                            Console.ReadLine();
                            newBoardGame = false;
                        }
                        else if (print != "y")
                        {
                            newBoardGame = false;
                        }
                    }
                }
            }
        }
    }
}
