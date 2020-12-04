using BusinessLogic;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            BooksService bs = new BooksService();
            GenresService gs = new GenresService();


            int menuChoice = 0;
            do
            {
                ShowMenu();
                Console.WriteLine("Input menu choice: ");
                menuChoice = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                switch (menuChoice)
                {
                    case 1:
                        //Add Book

                        Book myBook = new Book();
                       
                        Console.WriteLine("Input book name: ");
                        myBook.Name = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Input book isbn: ");
                        myBook.Isbn = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Input book publisher: ");
                        myBook.Publisher = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Input book author: ");
                        myBook.Author = Console.ReadLine();

                        Console.WriteLine();
                        Console.WriteLine("Input book year: ");
                        myBook.Year = Convert.ToInt32(Console.ReadLine());

                        //get all the genres that i have in my db
                        Console.WriteLine();
                      
                        foreach (var g in gs.GetGenres())
                        {
                            Console.WriteLine($"{g.Id}. {g.Name}");
                        }
                        Console.WriteLine();
                       Console.WriteLine("Select one of the Genres by inputting the number next to the name: ");
                       myBook.GenreFK = Convert.ToInt32(Console.ReadLine());
                        
                        Console.WriteLine();

                        
                       bs.Add(myBook);
                       Console.WriteLine("Book was added successfully");
                       Console.WriteLine("Press a key to continue...");
                       Console.ReadKey();
                       
                        break;

                    case 2:
                        //Get Books
                        break;

                    case 3:
                        //Get Books by Genre

                        foreach (var g in gs.GetGenres())
                        {
                            Console.WriteLine($"{g.Id}. {g.Name}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Select one of the Genres by inputting the number next to the name: ");



                        break;

                    default:
                        if(menuChoice != 999)
                          Console.WriteLine("Input is not valid");
                        break;
                }

            } while (menuChoice != 999);
        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1.   Add a book");
            Console.WriteLine("2.   Get a list of books");
            Console.WriteLine("3.   Get a list of books by Genre");
            Console.WriteLine("999. Quit");
        }



    }
}
