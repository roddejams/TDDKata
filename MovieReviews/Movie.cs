using System.Collections.Generic;

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
    }
}