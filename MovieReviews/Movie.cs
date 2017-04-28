using System.Collections.Generic;

namespace MovieReviews
{
    public class Movie
    {
        private readonly List<MovieReview> m_Reviews = new List<MovieReview>();

        public Movie(string title)
        {
            
        }

        public void AddReview(MovieReview newReview)
        {
            m_Reviews.Add(newReview);
        }

        public List<MovieReview> GetReviews()
        {
            return m_Reviews;
        }
    }
}