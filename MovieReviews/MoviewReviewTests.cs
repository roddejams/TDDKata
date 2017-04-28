using NUnit.Framework;

namespace MovieReviews
{
    public class MovieReviewTests
    {
        [Test]
        public void CanAddAReview()
        {
            var testMovie = new Movie("Test");
            var basicReview = new Review();

            testMovie.AddReview(basicReview);

            Assert.That(testMovie.GetReviews(), Is.Not.Empty);
        }
    }
}
