using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Exceptions
{
    public class ScGpsValidationException : Exception
    {
        public ICollection<ValidationError> Errors { get; set; }

        public ScGpsValidationException(ICollection<ValidationError> errors)
        {
            Errors = errors;
        }
    }
}
