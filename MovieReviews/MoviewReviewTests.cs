using System.Linq;
using NUnit.Framework;

namespace MovieReviews
{
    public class MovieReviewTests
    {
        [Test]
        public void CanAddAReview()
        {
            var testMovie = new Movie("Test");
            var basicReview = new Review(5);

            testMovie.AddReview(basicReview);

            Assert.That(testMovie.GetReviews(), Is.Not.Empty);
        }

        [Test]
        public void ShouldGetReviewRating()
        {
            var testMovie = new Movie("Test");
            var review = new Review(5);

            testMovie.AddReview(review);

            var addedReview = testMovie.GetReviews().First();
            Assert.That(addedReview.Rating(), Is.EqualTo(5));
        }

        [Test]
        public void ShouldGetTheNameOfTheReviewer()
        {
            var testMovie = new Movie("Test");
            var review = new Review(5, "James");

            testMovie.AddReview(review);

            var addedReview = testMovie.GetReviews().First();
            Assert.That(addedReview.ReviewerName(), Is.EqualTo("James"));
        }

        [Test]
        public void DefaultNameShouldBeAnonymous()
        {
            var movie = new Movie("Test");
            var unamedReview = new Review(5);

            movie.AddReview(unamedReview);

            var addedReview = movie.GetReviews().First();
            Assert.That(addedReview.ReviewerName(), Is.EqualTo("Anonymous"));
        }
    }
}
