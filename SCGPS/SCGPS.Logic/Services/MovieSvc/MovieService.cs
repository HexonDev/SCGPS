using AutoMapper;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using SCGPS.Data;
using SCGPS.Data.Entities;
using SCGPS.Domain.Commands;
using SCGPS.Domain.Commands.MovieSvc;
using SCGPS.Domain.Results;
using SCGPS.Domain.Results.Entity;
using SCGPS.Logic.Services.Entity;
using SCGPS.Logic.Services.OmdbSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic.Services.MovieSvc
{
    internal class MovieService : EntityService<Movie>, IMovieService
    {
        private readonly IExecuter executer;
        private readonly IAppDbContext context;
        private readonly IOmdbService omdbService;
        private readonly IMapper mapper;

        public MovieService(IExecuter executer, IAppDbContext context, IOmdbService omdbService, IMapper mapper) : base(executer, context)
        {
            this.executer = executer ?? throw new ArgumentNullException(nameof(executer));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.omdbService = omdbService ?? throw new ArgumentNullException(nameof(omdbService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SimpleResult<Movie>> AddMovieAsync(MovieTitleCommand command)
        {
            return await executer.ExecuteAsync(command, this.GetType(), async param =>
            {
                var movie = context.Movies.FirstOrDefault(context => context.Title == param.Title);

                if(movie == null)
                {
                    var omdbMovieResult = await omdbService.GetOmdbMovieByTitleAsync(new() { Title = param.Title });
                    omdbMovieResult.ThrowIfNotSucceded();

                    var imdbRating = omdbMovieResult.Result.Ratings.FirstOrDefault(r => r.Source == "Internet Movie Database")?.Value;

                    var newMovie = new Movie()
                    {
                        Actors = omdbMovieResult.Result.Actors,
                        Genre = omdbMovieResult.Result.Genre,
                        PosterUrl = omdbMovieResult.Result.Poster,
                        Title = omdbMovieResult.Result.Title,
                        Year = DateTime.Parse($"{omdbMovieResult.Result.Year}-01-01"),
                        ImdbRating = imdbRating,
                        Plot = omdbMovieResult.Result.Plot
                    };

                    var movieEntityResult = await AddOrModifyAsync(new() { Entity = newMovie });
                    movieEntityResult.ThrowIfNotSucceded();
                    movie = movieEntityResult.Entity;
                }
            

                return new SimpleResult<Movie>(movie);      
            });
        }

        public async Task<SimpleResult<Movie[]>> GetMoviesAsync(GetMoviesCommand command)
        {
            return await executer.ExecuteAsync(command, this.GetType(), async param =>
            {
                var movies = context.Movies.AsQueryable();

                if(param.Year != null)
                {
                    movies = movies.Where(m => m.Year == param.Year);
                }

                if(param.Title != null)
                {
                    movies = movies.Where(m => m.Title.Contains(param.Title));
                }

                if (param.OrderBy != null && param.Order == Order.Descending)
                {
                    movies = movies.OrderByDescending(m => EF.Property<object>(m, param.OrderBy));
                }
                else if (param.OrderBy != null)
                {
                    movies = movies.OrderBy(m => EF.Property<object>(m, param.OrderBy));
                }
                
                return new SimpleResult<Movie[]>
                {
                    Result = movies.ToArray(),
                };
            });
        }
    }
}
