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

        [Test]
        public void ShouldCalculateTheAverageRatingOfAMovie()
        {
            var review1 = new Review(1, "Awful"); 
            var review2 = new Review(2, "Pretty bad"); 
            var review3 = new Review(3, "Mediocre"); 
            var review4 = new Review(4, "Good");
            var movie = GetTestMovie(review1, review2, review3, review4);

            Assert.That(movie.CalculateAverageRating(), Is.EqualTo(2.5));
        }

        [Test]
        public void ShouldGetTheNumberOfReviewsForEachRating()
        {
            var review1 = new Review(1, "Awful");
            var review2 = new Review(1, "Terrible");
            var review3 = new Review(1, "Disasterous");

            var review4 = new Review(3, "Average");

            var movie = GetTestMovie(review1, review2, review3, review4);

            Assert.That(movie.NumberOfReviewsWithRating(1), Is.EqualTo(3));
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
