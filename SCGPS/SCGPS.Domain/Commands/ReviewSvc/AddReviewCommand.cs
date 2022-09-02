using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Commands.ReviewSvc
{
    public class AddReviewCommand : ServiceCommand
    {
        public uint MovieId { get; set; }
        public string ReviewText { get; set; }
    }
}
