using SCGPS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Exceptions
{
    public class ScGpsException : Exception
    {
        public ErrorCodes ErrorCode { get; set; }

        public ScGpsException(ErrorCodes errorCode)
        {
            ErrorCode = errorCode;
        }
    }
}
