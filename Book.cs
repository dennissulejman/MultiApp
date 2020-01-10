using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MultiApp
{
    internal class Book
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public override string ToString()
        {
            return "Title: " + Title + "Year: " + ReleaseYear;
        }
        public static void ListMethod()
        {
            List<Book> myBooks = new List<Book>();
            Console.Clear();
            bool newBook = true;
            while (newBook)
            {                
                Console.WriteLine("What is the title of your book?");
                string title = Console.ReadLine();
                Console.WriteLine("Which year did it come out?");
                int year = int.Parse(Console.ReadLine());
                myBooks.Add(new Book() { Title = title + ", ", ReleaseYear = year });

                Console.WriteLine("Add another book?(Y/N)");
                string response = Console.ReadLine();
                if (response == "y")
                {
                    newBook = true;
                }
                else if (response == "n")
                {
                    newBook = false;
                    Console.WriteLine("These are the books in your collection:");
                    Console.WriteLine();
                    StringBuilder Books = new StringBuilder();                   
                    Books.AppendLine("My Collection of Books:");
                    Books.AppendLine();
                    foreach (Book aBook in myBooks)                        
                    {
                        Books.AppendLine(aBook.ToString());

                    }
                    Console.WriteLine(Books.ToString());
                    {
                        Console.WriteLine("Would you like to print your collection of books to a file?(Y/N)");
                        string print = (Console.ReadLine());
                        if (print == "y")
                        {
                            
                            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
                                + @"\BookCollection.txt", Books.ToString());
                            Console.WriteLine("Your collection was printed successfully!");
                            Console.ReadLine();
                            newBook = false;
                        }
                        else if (print != "y")
                        {
                            newBook = false;
                        }
                    }
                }
            }
        }
    }
}
