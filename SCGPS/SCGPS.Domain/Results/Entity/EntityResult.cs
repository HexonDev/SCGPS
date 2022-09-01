using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Results.Entity
{
    public class EntityResult<T> : ServiceResult where T : class
    {
        public EntityResult()
        {

        }

        public EntityResult(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; set; }
    }
}
