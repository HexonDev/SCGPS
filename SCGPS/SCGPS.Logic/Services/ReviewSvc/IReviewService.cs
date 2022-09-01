using SCGPS.Data.Entities;
using SCGPS.Domain.Commands.ReviewSvc;
using SCGPS.Domain.Results;
using SCGPS.Logic.Services.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic.Services.ReviewSvc
{
    public interface IReviewService : IEntityService<Review>
    {
        Task<SimpleResult<Review>> AddReviewAsync(AddReviewCommand command);
        Task<SimpleResult<Review[]>> GetReviewsAsync(GetReviewsCommand command);
    }
}
