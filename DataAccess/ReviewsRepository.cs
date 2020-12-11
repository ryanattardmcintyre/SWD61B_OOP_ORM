using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ReviewsRepository : ConnectionClass
    {
        public ReviewsRepository():base()
        { }

        
        public void Add(Review r)
        {
            MyConnection.Reviews.Add(r);
            MyConnection.SaveChanges();
        }

        public IQueryable<Review> GetReviews() //Instead of IQueryable you can use IEnumerable, IList, List, .....
        {
            return MyConnection.Reviews;
        }

    }
}
