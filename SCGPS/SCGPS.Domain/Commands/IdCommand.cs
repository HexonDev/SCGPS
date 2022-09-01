﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Commands
{
    public class IdCommand : ServiceCommand
    {
        public ulong Id { get; set; }

        public IdCommand(ulong id)
        {
            Id = id;
        }
    }
}
