using SCGPS.Data.Entities;
using SCGPS.Domain.Commands;
using SCGPS.Domain.Commands.MovieSvc;
using SCGPS.Domain.Results;
using SCGPS.Domain.Results.Entity;
using SCGPS.Logic.Services.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic.Services.MovieSvc
{
    public interface IMovieService : IEntityService<Movie>
    {
        Task<SimpleResult<Movie>> AddMovieAsync(MovieTitleCommand command);
        Task<SimpleResult<Movie[]>> GetMoviesAsync(GetMoviesCommand command);
    }
}
