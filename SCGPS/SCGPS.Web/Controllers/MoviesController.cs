using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCGPS.Domain.Commands.MovieSvc;
using SCGPS.Domain.Dto;
using SCGPS.Logic.Services.MovieSvc;
using SCGPS.Logic.Services.OmdbSvc;

namespace SCGPS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ScGpsControllerBase
    {
        private readonly IMovieService movieService;
        private readonly IMapper mapper;

        public MoviesController(IMovieService movieService, IOmdbService omdbService, IMapper mapper)
        {
            this.movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<MoviesDto>> GetMovies(string? title, string? orderBy, string? year, Order order = Order.Ascending)
        {
            var getCommand = new GetMoviesCommand()
            {
                Title = title,
                Order = order,
                OrderBy = orderBy,
            };

            DateTime rYear;
            if(DateTime.TryParse($"{year}-01-01", out rYear))
            {
                getCommand.Year = rYear;
            }

            var moviesResult = await movieService.GetMoviesAsync(getCommand);
            var moviesDto = mapper.Map<MoviesDto>(moviesResult);

            return EnsureResult(moviesResult, moviesDto);
        }

        [HttpPost]
        public async Task<ActionResult<MovieDto>> PostMovie(MovieTitleDto dto)
        {
            var movieResult = await movieService.AddMovieAsync(new() { Title = dto.Title });
            var movieDto = mapper.Map<MovieDto>(movieResult.Result);

            return EnsureResult(movieResult, movieDto);
        }
    }
}
