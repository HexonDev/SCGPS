using FluentValidation;
using SCGPS.Domain.Commands.MovieSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic.Validators.MovieSvc
{
    public class GetMoviesCommandValidator : AbstractValidator<GetMoviesCommand>
    {
        public GetMoviesCommandValidator()
        {
            
        }
    }
}
