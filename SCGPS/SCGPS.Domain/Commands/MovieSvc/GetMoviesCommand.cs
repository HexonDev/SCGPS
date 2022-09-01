using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Commands.MovieSvc
{
    public class GetMoviesCommand : ServiceCommand
    {
        public DateTime? Year { get; set; }
        public string? Title { get; set; }
        public string? OrderBy { get; set; }
        public Order Order { get; set; } = Order.Ascending;
    }

    public enum Order
    {
        Ascending = 'A',
        Descending = 'D'
    }
}
