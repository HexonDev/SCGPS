using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Commands
{
    public class IdCommand : ServiceCommand
    {
        public uint Id { get; set; }

        public IdCommand(uint id)
        {
            Id = id;
        }
    }
}
