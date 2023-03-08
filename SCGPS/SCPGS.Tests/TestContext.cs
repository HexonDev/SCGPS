using AutoMapper;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using SCGPS.Data;
using SCGPS.Data.Entities;
using SCGPS.Logic;
using SCGPS.Logic.MappingProfiles;
using SCGPS.Logic.Services.MovieSvc;
using SCGPS.Logic.Services.OmdbSvc;
using SCGPS.Logic.Services.ReviewSvc;

namespace SCPGS.Tests
{
    [TestClass]
    public static class TestContext
    {
        public static MovieService MovieService { get; private set; }
        public static OmdbService OmdbService { get; private set; }
        public static ReviewService ReviewService { get; private set; }
        private static Executer _executer;

        [AssemblyInitialize]
        public static void AssemblyInitialize(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext tc)
        {
            var connection = new SqliteConnection("Data Source=SCGPS");

            var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite(connection).Options;

            AppDbContext appDbContext = new AppDbContext(options);

            appDbContext.Database.EnsureDeleted();
            appDbContext.Database.EnsureCreated();
            //appDbContext.Database.Migrate();

            appDbContext.Movies.AddRange(
                new Movie { 
                    Id = 1, 
                    Title = "Teszt 1", 
                    Year = new DateTime(2001),
                    Actors = "Teszt színész 1, Teszt színész 2", 
                    Genre = "Műfaj 1", 
                    ImdbRating = "6.0/10", 
                    Plot = "Plot 1", 
                    PosterUrl = "posterUrl" },
                new Movie { 
                    Id = 2, 
                    Title = "Teszt 2", 
                    Year = new DateTime(2002),
                    Actors = "Teszt színész 3, Teszt színész 4", 
                    Genre = "Műfaj 2", 
                    ImdbRating = "1.0/10", 
                    Plot = "Plot 2", 
                    PosterUrl = "posterUrl2" }
            );

            appDbContext.Reviews.AddRange(
                new Review { MovieId = 1, ReviewText = "Értékelés 1-1"  },
                new Review { MovieId = 1, ReviewText = "Értékelés 1-2"  },
                new Review { MovieId = 2, ReviewText = "Értékelés 2-1"  },
                new Review { MovieId = 2, ReviewText = "Értékelés 2-2"  },
                new Review { MovieId = 2, ReviewText = "Értékelés 2-3"  }
            );
            appDbContext.SaveChanges();

            var serviceProviderMock = new Mock<IServiceProvider>();
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            //httpClientFactoryMock.Setup(x => x.CreateClient()).Returns(new HttpClient());

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var mappingConfiguration = new MapperConfiguration(mc =>
            {
                mc.Internal().MethodMappingEnabled = false;
                mc.AddProfile(new MovieProfile());
                mc.AddProfile(new OmdMovieProfile());
                mc.AddProfile(new ReviewProfile());
            });

            var mapper = mappingConfiguration.CreateMapper();

            _executer = new Executer(appDbContext, serviceProviderMock.Object);

            serviceProviderMock.Setup(x => x.GetService(typeof(IExecuter))).Returns(_executer);

            OmdbService = new OmdbService(_executer, httpClientFactoryMock.Object, config);
            MovieService = new MovieService(_executer, appDbContext, OmdbService, mapper);
            ReviewService = new ReviewService(_executer, appDbContext, MovieService);

            serviceProviderMock.Setup(x => x.GetService(typeof(IOmdbService))).Returns(OmdbService);
            serviceProviderMock.Setup(x => x.GetService(typeof(IMovieService))).Returns(MovieService);
            serviceProviderMock.Setup(x => x.GetService(typeof(IReviewService))).Returns(ReviewService);
        }
    }
}
