using Common;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BooksService
    {

        private BookRepository _booksRepo;
        public BooksService( )
        {
            _booksRepo = new BookRepository(); //DATAACCESS
        }

        public bool Add(Book b)
        {
            if (_booksRepo.GetBooks().SingleOrDefault(x=>x.Isbn == b.Isbn) == null)
            {
                  _booksRepo.Add(b);
                return true;
            }
            return false;
        }

        public List<Book> GetBooks() //using List because the presentation is going get a definite/final list
        {
            return _booksRepo.GetBooks().ToList();
        }

        public List<Book> GetBooks(int genreId)
        {
            //Select * From books where GenreFk = genreId;

          return _booksRepo.GetBooks().Where(book => book.GenreFK == genreId  ).ToList(); //lambda

           /* var list = from book in _booksRepo.GetBooks()
                       where book.GenreFK == genreId
                       select book;
            return list.ToList();*/
        }

        public int GetTotalNoOfBooks()
        {
            //Select Count(Isbn) from Books

            return _booksRepo.GetBooks().Count();
        }

        public List<Book> GetBooksSorted(int sortBy)
        {
            switch (sortBy)
            {
                case 1:
                    return _booksRepo.GetBooks().OrderBy(x => x.Name).ToList();

                case 2:
                    return _booksRepo.GetBooks().OrderBy(x => x.Author).ToList();

                case 3:

                    var list = from book in _booksRepo.GetBooks()
                               orderby book.Year ascending
                               select book;
                    return list.ToList();


                default:
                    return _booksRepo.GetBooks().ToList();
            }
        }

        public void Delete(string isbn)
        {
            var myBookToDelete = _booksRepo.GetBook(isbn); //return ONE or null single book!! 
            if (myBookToDelete != null)
            {
                _booksRepo.Delete(myBookToDelete);
            }
        }

        public void Update(string isbn, string newName, int newYear, string newPublisher, string newAuthor, int newGenre)
        {
            var myBookToUpdate = _booksRepo.GetBook(isbn);
            myBookToUpdate.Name = newName;
            myBookToUpdate.Year = newYear;
            myBookToUpdate.Publisher = newPublisher;
            myBookToUpdate.GenreFK = newGenre;
            myBookToUpdate.Author = newAuthor;

            _booksRepo.Update(myBookToUpdate); //SqlException

        }


        /*
         *   Author    Total
         *   
         *   Peppi     5
         *   Joe       10
         * 
         * 
         */

        public List<AuthorBook> GetAuthorWithNoOfBooks()
        {
            //g1: Peppi  -->> Book1/ Book2/ Book3
            //g2: Cikku  -->> Book4/ Book5/ Book6/ Book7
            //g3: Joe
            //g4: Pietru

            //raw linq
            var list = from book in _booksRepo.GetBooks()
                       group book by book.Author into g
                       select new AuthorBook()
                       { Author = g.Key, Total = g.Count() };

            return list.ToList();
        }



    }
}
