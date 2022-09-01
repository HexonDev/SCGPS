using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Results
{
    public class ServiceResult : IServiceResult
    {
        public Exception Exception { get; set; }
        public bool IsSucceded { get; set; }
        public DateTime Time { get; set; }
    }
}
