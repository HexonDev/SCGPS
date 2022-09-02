using FluentValidation;
using SCGPS.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic.Validators
{
    public class IdCommandValidator : AbstractValidator<IdCommand>
    {
        public IdCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0u);
        }
    }
}
