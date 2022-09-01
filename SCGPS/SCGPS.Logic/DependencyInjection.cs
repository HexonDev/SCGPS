using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCGPS.Data.Entities;
using SCGPS.Domain.Commands.Entity;
using SCGPS.Domain.Commands.MovieSvc;
using SCGPS.Logic.Services.MovieSvc;
using SCGPS.Logic.Services.OmdbSvc;
using SCGPS.Logic.Services.ReviewSvc;
using SCGPS.Logic.Validators.MovieSvc;
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
            services.AddScoped<AbstractValidator<EntityCommand<Review>>, ReviewEntityCommandValidator>();
            services.AddScoped<AbstractValidator<MovieTitleCommand>, MovieTitleCommandValidator>();
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
