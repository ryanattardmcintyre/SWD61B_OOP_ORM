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

        public IQueryable<Book> GetBooks()
        {
            return MyConnection.Books;
        }

       

    }
}
