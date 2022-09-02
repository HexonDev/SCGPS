using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Dto
{
    public class ReviewDto : BaseIdDto
    {
        public uint MovieId { get; set; }
        public string ReviewText { get; set; }
    }
}
