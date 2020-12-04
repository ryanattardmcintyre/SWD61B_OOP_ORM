using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GenresRepository: ConnectionClass
    {
        public GenresRepository() : base() { }

        public IQueryable<Genre> GetGenres()
        { return MyConnection.Genres; }
    }
}
