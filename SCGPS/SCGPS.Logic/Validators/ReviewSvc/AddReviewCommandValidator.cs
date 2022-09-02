using FluentValidation;
using SCGPS.Domain.Commands.ReviewSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic.Validators.ReviewSvc
{
    public class AddReviewCommandValidator : AbstractValidator<AddReviewCommand>
    {
        public AddReviewCommandValidator()
        {
            RuleFor(x => x.ReviewText).NotEmpty();
            RuleFor(x => x.MovieId).GreaterThan(0u);
        }
    }
}
