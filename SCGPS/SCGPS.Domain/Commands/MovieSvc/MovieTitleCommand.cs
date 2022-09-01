using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Commands.MovieSvc
{
    public class MovieTitleCommand : ServiceCommand
    {
        public string Title { get; set; }
    }
}
