using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Commands.ReviewSvc
{
    public class GetReviewsCommand : ServiceCommand
    {
        public ulong? MovieId { get; set; }
    }
}
