using SCGPS.Domain.Commands.MovieSvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPGS.Tests
{
    
    [TestClass]
    public class MovieServiceTests
    {
        [TestMethod]
        public async Task GetMoviesAsync_ValidData_Success() 
        {
            var movieResult = await TestContext.MovieService.GetMoviesAsync(new GetMoviesCommand());

            Assert.AreEqual(1, movieResult.Result.Length);
            Assert.AreEqual("Teszt 1", movieResult.Result[0].Title);
        }

        [TestMethod]
        public async Task GetReviewsAsync_ValidData_Success() 
        {
            var reviewResult = await TestContext.ReviewService.GetReviewsAsync(new());

            Assert.AreEqual(5, reviewResult.Result.Length);
        }

        [ExcludeFromCodeCoverage]
        [Ignore("Nem volt idő átírni")]
        [DataTestMethod]
        [DataRow(1u, 2)]
        [DataRow(2u, 3)]
        public async Task GetReviewsAsync_MovieId2_Success(uint movieId, int expected) 
        {
            var reviewResult = await TestContext.ReviewService.GetReviewsAsync(new() { MovieId = movieId });

            Assert.AreEqual(expected, reviewResult.Result.Length);
        }
    }
}
