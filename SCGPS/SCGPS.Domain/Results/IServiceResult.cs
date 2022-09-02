using SCGPS.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Results
{
    public interface IServiceResult
    {
        ScGpsException Exception { get; set; }
        bool IsSucceded { get; set; }
        DateTime Time { get; set; }
        void ThrowIfNotSucceded();
    }
}
