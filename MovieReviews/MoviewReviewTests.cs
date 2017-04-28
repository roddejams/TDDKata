using System.Linq;
using NUnit.Framework;

namespace MovieReviews
{
    public class MovieReviewTests
    {
        [Test]
        public void CanAddAReview()
        {
            var testMovie = SetupTestMovieWithReview();

            Assert.That(testMovie.GetReviews(), Is.Not.Empty);
        }

        [Test]
        public void ShouldGetReviewRating()
        {
            var testMovie = SetupTestMovieWithReview();

            var addedReview = testMovie.GetReviews().First();
            Assert.That(addedReview.Rating(), Is.EqualTo(5));
        }

        [Test]
        public void ShouldGetTheNameOfTheReviewer()
        {
            var testMovie = SetupTestMovieWithReview();

            var addedReview = testMovie.GetReviews().First();
            Assert.That(addedReview.ReviewerName(), Is.EqualTo("James"));
        }

        [Test]
        public void DefaultNameShouldBeAnonymous()
        {
            var unamedReview = new Review(5, "Review");
            var movie = SetupTestMovieWithReview(unamedReview);

            var addedReview = movie.GetReviews().First();
            Assert.That(addedReview.ReviewerName(), Is.EqualTo("Anonymous"));
        }

        [Test]
        public void ShouldGetTheTextOfTheReview()
        {
            var testMovie = SetupTestMovieWithReview();

            var addedReview = testMovie.GetReviews().First();
            Assert.That(addedReview.Text(), Is.EqualTo("TestReview"));
        }

        private static Movie SetupTestMovieWithReview(Review review = null)
        {
            var testMovie = new Movie("Test");
            review = review ?? new Review(5, "James", "TestReview");

            testMovie.AddReview(review);
            return testMovie;
        }
    }
}
