﻿using System.Linq;
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
    }
}