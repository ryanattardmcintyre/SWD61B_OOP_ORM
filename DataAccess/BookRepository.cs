using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    //In the DataAccess we will implement code that will interact DIRECTLY with the database

    public class BookRepository: ConnectionClass
    {
        public BookRepository():base()
        { }


        //ADD a book

        public void Add(Book b ) //sql: Insert
        {
            MyConnection.Books.Add(b);
            MyConnection.SaveChanges();
        }

        public IQueryable<Book> GetBooks() //Select
        {
            return MyConnection.Books;
        }


        public void Delete(Book b)
        {
            MyConnection.Books.Remove(b);
            MyConnection.SaveChanges();
        }

        public void Update(Book withNewDetails)
        {
            MyConnection.SaveChanges();

        }

        public Book GetBook(string isbn)
        {
            return MyConnection.Books.SingleOrDefault(x => x.Isbn == isbn);

        }
       

    }
}
