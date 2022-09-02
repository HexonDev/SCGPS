using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCGPS.Data.Entities;
using SCGPS.Domain.Commands;
using SCGPS.Domain.Commands.Entity;
using SCGPS.Domain.Commands.MovieSvc;
using SCGPS.Domain.Commands.OmdbSvc;
using SCGPS.Domain.Commands.ReviewSvc;
using SCGPS.Logic.Services.MovieSvc;
using SCGPS.Logic.Services.OmdbSvc;
using SCGPS.Logic.Services.ReviewSvc;
using SCGPS.Logic.Validators;
using SCGPS.Logic.Validators.MovieSvc;
using SCGPS.Logic.Validators.OmdbSvc;
using SCGPS.Logic.Validators.ReviewSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLogicLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IExecuter, Executer>();
            services.AddHttpClient();
            services.AddAutoMapper(typeof(DependencyInjection));

            #region Validátorok
            services.AddScoped<AbstractValidator<EntityCommand<Movie>>, MovieEntityCommandValidator>();
            services.AddScoped<AbstractValidator<MovieTitleCommand>, MovieTitleCommandValidator>();
            services.AddScoped<AbstractValidator<GetMoviesCommand>, GetMoviesCommandValidator>();

            services.AddScoped<AbstractValidator<GetOmdbMovieCommand>, GetOmdbMovieCommandValidator>();

            services.AddScoped<AbstractValidator<EntityCommand<Review>>, ReviewEntityCommandValidator>();
            services.AddScoped<AbstractValidator<AddReviewCommand>, AddReviewCommandValidator>();
            services.AddScoped<AbstractValidator<GetReviewsCommand>, GetReviewsCommandValidator>();

            services.AddScoped<AbstractValidator<IdCommand>, IdCommandValidator>();
            #endregion

            #region Servicek
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IOmdbService, OmdbService>();
            #endregion



            return services;
        }
    }
}
