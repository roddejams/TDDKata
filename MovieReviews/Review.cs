using NUnit.Framework.Constraints;

namespace MovieReviews
{
    public class Review
    {
        private readonly int _rating;
        private readonly string _reviewerName;

        public Review(int rating)
        {
            _rating = rating;
        }

        public Review(int rating, string reviewerName) : this(rating)
        {
            _reviewerName = reviewerName;
        }

        public int Rating()
        {
            return _rating;
        }

        public string ReviewerName()
        {
            return _reviewerName ?? "Anonymous";
        }
    }
}