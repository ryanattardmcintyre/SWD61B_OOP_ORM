﻿using Common;
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
            MyConnection = new LibraryBooksEntities();
        }


    }
}
