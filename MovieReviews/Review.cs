using NUnit.Framework.Constraints;

namespace MovieReviews
{
    public class Review
    {
        private readonly int m_rating;

        public Review(int rating)
        {
            m_rating = rating;
        }

        public int Rating()
        {
            return m_rating;
        }
    }
}