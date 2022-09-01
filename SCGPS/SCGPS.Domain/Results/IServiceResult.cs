using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Results
{
    public interface IServiceResult
    {
        Exception Exception { get; set; }
        bool IsSucceded { get; set; }
        DateTime Time { get; set; }
    }
}
