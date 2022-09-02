using FluentValidation;
using SCGPS.Domain.Commands.OmdbSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic.Validators.OmdbSvc
{
    public class GetOmdbMovieCommandValidator : AbstractValidator<GetOmdbMovieCommand>
    {
        public GetOmdbMovieCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
