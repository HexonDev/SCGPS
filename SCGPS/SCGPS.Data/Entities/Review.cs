using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Data.Entities
{
    public class Review : BaseEntity
    {
        public uint MovieId { get; set; }
        public Movie Movie { get; set; }
        public string ReviewText { get; set; }
    }
}
