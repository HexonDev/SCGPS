using SCGPS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Commands.Entity
{
    public class EntityCommand<T> : ServiceCommand where T : BaseEntity
    {
        public T Entity { get; set; }
    }
}
