using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Data.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public string Genre { get; set; }
        public string Actors { get; set; }
        public string PosterUrl { get; set; }
        public string ImdbRating { get; set; }

        ICollection<Review> Reviews { get; set;}
    }
}
