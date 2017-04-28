using NUnit.Framework.Constraints;

namespace MovieReviews
{
    public class Review
    {
        private readonly int _rating;
        private readonly string _text;
        private readonly string _reviewerName;

        public Review(int rating, string text)
        {
            _rating = rating;
            _text = text;
        }

        public Review(int rating, string reviewerName, string text) : this(rating, text)
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

        public string Text()
        {
            return "";
        }
    }
}