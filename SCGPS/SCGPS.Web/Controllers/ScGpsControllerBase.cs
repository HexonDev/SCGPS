using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCGPS.Domain.Dto;
using SCGPS.Domain.Results;

namespace SCGPS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScGpsControllerBase : ControllerBase
    {
        public ActionResult<T> EnsureResult<T>(IServiceResult result, T dto = null) where T : BaseDto, new()
        {
            if(dto == null)
            {
                dto = new T();
            }

            dto.IsSucceded = result.IsSucceded;
            dto.Time = result.Time;

            if (result.IsSucceded)
            {
                return Ok(dto);
            }

            return StatusCode(500, dto);
        }

    }
}
