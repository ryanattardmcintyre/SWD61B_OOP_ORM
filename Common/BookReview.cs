using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class BookReview
    {
        public string Isbn { get; set; }
        public int TotalReviews { get; set; }

        public double AvgRating { get; set; }
    }
}
