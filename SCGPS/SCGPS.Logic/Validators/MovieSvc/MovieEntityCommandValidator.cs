using FluentValidation;
using SCGPS.Data.Entities;
using SCGPS.Domain.Commands.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic.Validators.MovieSvc
{
    internal class MovieEntityCommandValidator : AbstractValidator<EntityCommand<Movie>>
    {
        public MovieEntityCommandValidator()
        {
            RuleFor(x => x.Entity).NotNull();
            When(x => x.Entity != null, () =>
            {
                RuleFor(x => x.Entity.Title).NotEmpty();
                RuleFor(x => x.Entity.Genre).NotEmpty();
                RuleFor(x => x.Entity.Actors).NotEmpty();
                RuleFor(x => x.Entity.Genre).NotEmpty();
                RuleFor(x => x.Entity.PosterUrl).NotEmpty();
            });
        }
    }
}
