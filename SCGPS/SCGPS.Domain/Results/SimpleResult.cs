using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Results
{
    public class SimpleResult<T> : ServiceResult
    {
        public T Result { get; set; }

        public SimpleResult(T result)
        {
            Result = result;
        }

        public SimpleResult()
        {

        }
    }
}
