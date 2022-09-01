using FluentValidation;
using SCGPS.Data.Entities;
using SCGPS.Domain.Commands.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic.Validators.ReviewSvc
{
    internal class ReviewEntityCommandValidator : AbstractValidator<EntityCommand<Review>>
    {
        public ReviewEntityCommandValidator()
        {
            RuleFor(x => x.Entity).NotNull();
            When(x => x.Entity != null, () =>
            {
                RuleFor(x => x.Entity.ReviewText).NotEmpty();
                RuleFor(x => x.Entity.Movie).NotNull();
                RuleFor(x => x.Entity.MovieId).GreaterThan(0u);
            });
        }
    }
}
