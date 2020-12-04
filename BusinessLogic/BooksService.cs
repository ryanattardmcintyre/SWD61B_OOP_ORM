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

          return _booksRepo.GetBooks().Where(book => book.GenreFK == genreId).ToList(); //lambda

           /* var list = from book in _booksRepo.GetBooks()
                       where book.GenreFK == genreId
                       select book;
            return list.ToList();*/
        }

    }
}
