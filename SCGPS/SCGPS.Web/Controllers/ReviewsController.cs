using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCGPS.Domain.Dto;
using SCGPS.Logic.Services.MovieSvc;
using SCGPS.Logic.Services.ReviewSvc;

namespace SCGPS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ScGpsControllerBase
    {
        private readonly IReviewService reviewService;
        private readonly IMapper mapper;

        public ReviewsController(IReviewService reviewService, IMapper mapper)
        {
            this.reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<ActionResult<ReviewDto>> PostReview(ReviewDto dto)
        {
            var result = await reviewService.AddReviewAsync(new()
            {
                MovieId = dto.MovieId,
                ReviewText = dto.ReviewText,
            });

            var reviewDto = mapper.Map<ReviewDto>(result.Result);

            return EnsureResult(result, reviewDto);
        }

        [HttpGet]
        public async Task<ActionResult<ReviewsDto>> GetReviews(uint? movieId)
        {
            var result = await reviewService.GetReviewsAsync(new()
            {
                MovieId = movieId
            });
            var reviewsDto = mapper.Map<ReviewsDto>(result);

            return EnsureResult(result, reviewsDto);
        }
    }
}
