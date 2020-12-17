using Common;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ReviewsService
    {
        private ReviewsRepository  _reviewRepo;
        private BookRepository _bookRepo;
        public ReviewsService()
        {
            _bookRepo = new BookRepository();
            _reviewRepo = new ReviewsRepository(); //DATAACCESS
        }


        public void ReviewABook(string isbn, string comment, int rating )
        {
           /* Book desiredBook;
            foreach (Book item in _bookRepo.GetBooks())
            {
                if (item.Isbn == isbn)
                {
                    desiredBook = item;
                    break;
                }
            }

            Review r = new Review();
            r.Comment = comment;
            r.Rating = rating;
            r.BookFK = isbn;

            _reviewRepo.Add(r);
           */




            if (_bookRepo.GetBooks().SingleOrDefault(item => item.Isbn == isbn) != null)
            {
                //shall allow the review to be added

                Review r = new Review();
                r.Comment = comment;
                r.Rating = rating;
                r.BookFK = isbn;

                _reviewRepo.Add(r);
                 
            }
        }

        public List<Review> GetReviews(string isbn)
        {
            var list = _reviewRepo.GetReviews().Where(r => r.BookFK == isbn).ToList(); //lambda
            return list;
        }


        public double GetAverageRatingOfBook(string isbn)
        {
            //the easy way
            double avgRating1 = GetReviews(isbn).Average(x => x.Rating);

            //the avg way
           //   Book b = _bookRepo.GetBook(isbn);
            //double avgRating = b.Reviews.Average(x => x.Rating);
            
            return avgRating1;
        }

        public List<BookReview>   GetBooksWithNoOfReviews()
        {
            /*
             *   Select Count(Id), BookFk 
             *   from Reviews
             *   group by BookFk
             */ 


            var list = from r in _reviewRepo.GetReviews()
                       group r by r.BookFK into g
                       select new BookReview()
                       {
                           Isbn = g.Key,
                           TotalReviews = g.Count(),
                           AvgRating = g.Average(a => a.Rating)
                       };

            return list.ToList();
        
        }



    }
}
