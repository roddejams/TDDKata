using System.Collections.Generic;
using System.Linq;

namespace MovieReviews
{
    public class Movie
    {
        private readonly List<Review> m_Reviews = new List<Review>();

        public Movie(string title)
        {
            
        }

        public void AddReview(Review newReview)
        {
            m_Reviews.Add(newReview);
        }

        public List<Review> GetReviews()
        {
            return m_Reviews;
        }

        public double CalculateAverageRating()
        {
            double sumOfRatings = m_Reviews.Sum(review => review.Rating());
            return sumOfRatings / m_Reviews.Count;
        }
    }
}