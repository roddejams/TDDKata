using System.Linq;
using NUnit.Framework;

namespace MovieReviews
{
    public class MovieReviewTests
    {
        [Test]
        public void CanAddAReview()
        {
            var testMovie = GetTestMovie();

            Assert.That(testMovie.GetReviews(), Is.Not.Empty);
        }

        [Test]
        public void ShouldGetReviewRating()
        {
            var testMovie = GetTestMovie();

            var addedReview = testMovie.GetReviews().First();
            Assert.That(addedReview.Rating(), Is.EqualTo(5));
        }

        [Test]
        public void ShouldGetTheNameOfTheReviewer()
        {
            var testMovie = GetTestMovie();

            var addedReview = testMovie.GetReviews().First();
            Assert.That(addedReview.ReviewerName(), Is.EqualTo("James"));
        }

        [Test]
        public void DefaultNameShouldBeAnonymous()
        {
            var unamedReview = new Review(5, "Review");
            var movie = GetTestMovie(unamedReview);

            var addedReview = movie.GetReviews().First();
            Assert.That(addedReview.ReviewerName(), Is.EqualTo("Anonymous"));
        }

        [Test]
        public void ShouldGetTheTextOfTheReview()
        {
            var testMovie = GetTestMovie();

            var addedReview = testMovie.GetReviews().First();
            Assert.That(addedReview.Text(), Is.EqualTo("TestReview"));
        }
         
        private static Movie GetTestMovie(params Review[] reviews)
        {
            var testMovie = new Movie("Test");

            if (reviews.Length == 0)
            {
                var defaultReview = new Review(5, "James", "TestReview");
                testMovie.AddReview(defaultReview);
            }
            else
            {
                foreach (var review in reviews)
                {
                    testMovie.AddReview(review);
                }
            }

            return testMovie;
        }
    }
}
