using FluentValidation;
using SCGPS.Domain.Commands.ReviewSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic.Validators.ReviewSvc
{
    public class GetReviewsCommandValidator : AbstractValidator<GetReviewsCommand>
    {
        public GetReviewsCommandValidator()
        {

        }
    }
}
