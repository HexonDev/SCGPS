using Microsoft.EntityFrameworkCore;
using SCGPS.Data;
using SCGPS.Data.Entities;
using SCGPS.Domain.Commands.ReviewSvc;
using SCGPS.Domain.Enums;
using SCGPS.Domain.Exceptions;
using SCGPS.Domain.Results;
using SCGPS.Logic.Services.Entity;
using SCGPS.Logic.Services.MovieSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic.Services.ReviewSvc
{
    public class ReviewService : EntityService<Review>, IReviewService
    {
        private readonly IExecuter executer;
        private readonly IAppDbContext context;
        private readonly IMovieService movieService;

        public ReviewService(IExecuter executer, IAppDbContext context, IMovieService movieService) : base(executer, context)
        {
            this.executer = executer ?? throw new ArgumentNullException(nameof(executer));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        }

        public async Task<SimpleResult<Review>> AddReviewAsync(AddReviewCommand command)
        {
            return await executer.ExecuteAsync(command, this.GetType(), async param =>
            {
                var movieResult = await movieService.GetByIdAsync(new(param.MovieId));
                movieResult.ThrowIfNotSucceded();
                var movie = movieResult.Entity;

                if (movie == null)
                    throw new ScGpsException(ErrorCodes.ReviewServiceMovieNotFound);

                var review = new Review()
                {
                    Movie = movie,
                    MovieId = movie.Id,
                    ReviewText = param.ReviewText,
                };

                await AddOrModifyAsync(new() { Entity = review });

                return new SimpleResult<Review>(review);
            });
        }

        public async Task<SimpleResult<Review[]>> GetReviewsAsync(GetReviewsCommand command)
        {
            return await executer.ExecuteAsync(command, this.GetType(), async param =>
            {
                var reviewsQuery = context.Reviews.AsQueryable();

                if(param.MovieId != null)
                {
                    reviewsQuery = reviewsQuery.Where(r => r.MovieId == param.MovieId.Value);
                }

                var reviews = await reviewsQuery.ToArrayAsync();

                return new SimpleResult<Review[]>(reviews);
            });
        }
    }
}
