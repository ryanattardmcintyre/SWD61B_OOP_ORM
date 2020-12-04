using Common;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class GenresService
    {
        private GenresRepository _genresRepo;

        public GenresService()
        { _genresRepo = new GenresRepository(); }

        public List<Genre> GetGenres()
        {
            return _genresRepo.GetGenres().ToList();
        }
    }
}
