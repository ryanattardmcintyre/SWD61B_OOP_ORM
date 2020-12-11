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
            ReviewsService rs = new ReviewsService();

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
                        List<Book> listOfAllBooks = bs.GetBooks();
                        DisplayListOfBooks(listOfAllBooks);
                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();
                        break;

                    case 3:
                        //Get Books by Genre

                        foreach (var g in gs.GetGenres())
                        {
                            Console.WriteLine($"{g.Id}. {g.Name}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Select one of the Genres by inputting the number next to the name: ");
                        int selectedGenre = Convert.ToInt32(Console.ReadLine());

                        //overloading
                        //static polymorphism
                        var listOfBooksFilteredByGenre = bs.GetBooks(selectedGenre);
                        DisplayListOfBooks(listOfBooksFilteredByGenre);
                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();



                        break;

                    case 4:
                        var total = bs.GetTotalNoOfBooks();

                        Console.WriteLine($"The total no of books in the library db is {total}");
                        Console.WriteLine();
                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();

                        break;

                    case 5:
                        Console.WriteLine("Please input the no. next to the field you want to sort books by");
                        Console.WriteLine("1. Name");
                        Console.WriteLine("2. Author");
                        Console.WriteLine("3. Year");
                        Console.WriteLine("Input 1-3: ");
                        int fieldChoice =   Convert.ToInt32(Console.ReadLine());

                        var sortedList = bs.GetBooksSorted(fieldChoice);
                        DisplayListOfBooks(sortedList);

                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();

                        break;

                    case 6:
                        break;

                    case 7:
                        break;

                    case 8:

                        Console.WriteLine("Author\t\tTotal");
                        foreach(AuthorBook item in bs.GetAuthorWithNoOfBooks())
                        {
                            Console.WriteLine($"{item.Author}\t\t{item.Total}");
                        }

                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();
                        break;

                    case 9:
                        
                        Console.WriteLine("Input isbn:");
                        string isbnForReview = Console.ReadLine();

                        Console.WriteLine("Input comment:");
                        string commentForReview = Console.ReadLine();

                        Console.WriteLine("Input rating:");
                        int ratingForReview = Convert.ToInt32(Console.ReadLine());

                        rs.ReviewABook(isbnForReview, commentForReview
                            , ratingForReview);

                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();

                        break;


                    case 10:

                        Console.WriteLine("Input isbn:");
                        string isbn1 = Console.ReadLine();

                        foreach (var r in rs.GetReviews(isbn1))
                        {

                        }
                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();
                        break;


                    case 11:
                        Console.WriteLine("Input isbn:");
                        string isbn2 = Console.ReadLine();

                        Console.WriteLine($"Avg rating for this book is {rs.GetAverageRatingOfBook(isbn2)}");
                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();
                        break;

                    case 12:

                        foreach (var item in rs.GetBooksWithNoOfReviews())
                        {
                            Console.WriteLine($"Book isbn {item.Isbn} has {item.TotalReviews} with avg rating of {item.AvgRating}");
                        }
                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();
                        break;


                    default:
                        if(menuChoice != 999)
                          Console.WriteLine("Input is not valid");
                        break;
                }

            } while (menuChoice != 999);
        }


        static void DisplayListOfBooks(List<Book> booksToDisplay)
        {
            foreach (Book b in booksToDisplay)
            {
                Console.WriteLine($"Isbn: {b.Isbn}\nName: {b.Name}\nAuthor: {b.Author}\nPublisher:{b.Publisher}\nYear: {b.Year}");
                Console.WriteLine($"Genre: {b.Genre.Name}");
                Console.WriteLine();
            }
        }


        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1.   Add a book");
            Console.WriteLine("2.   Get a list of books");
            Console.WriteLine("3.   Get a list of books by Genre");
            Console.WriteLine("4.   Show no. of books");
            Console.WriteLine("5.   Show books sorted by ...");
            Console.WriteLine("6.   Delete a book");
            Console.WriteLine("7.   Update book details");
            Console.WriteLine("8.   Show no. of books per Author");

            Console.WriteLine("9.   Review a book");
            Console.WriteLine("10.  Show Reviews per book");
            Console.WriteLine("11.  Calculate averate rating of a book");
            Console.WriteLine("12.  Show no of Reviews per book");

            Console.WriteLine("999. Quit");
        }



    }
}
