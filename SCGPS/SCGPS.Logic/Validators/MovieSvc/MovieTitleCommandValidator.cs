using FluentValidation;
using SCGPS.Domain.Commands.MovieSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic.Validators.MovieSvc
{
    internal class MovieTitleCommandValidator : AbstractValidator<MovieTitleCommand>
    {
        public MovieTitleCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
