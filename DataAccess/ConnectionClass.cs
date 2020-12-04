using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ConnectionClass
    {
        public LibraryBooksEntities MyConnection { get; set; }

        public ConnectionClass()
        {
            //instance which is of type LibraryBooksEntities contains methods that will
            //allow me to READ and WRITE data into or from the database

            MyConnection = new LibraryBooksEntities();
        }


    }
}
