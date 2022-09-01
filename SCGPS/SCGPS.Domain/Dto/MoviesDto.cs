using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Dto
{
    public class MoviesDto : BaseDto
    {
        public MovieDto[] Movies { get; set; }
    }
}
