using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCGPS.Domain;
using SCGPS.Domain.Dto;
using SCGPS.Domain.Enums;
using SCGPS.Domain.Exceptions;
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

            if(result.Exception != null)
            {
                dto.ErrorDescription = result.Exception.ErrorCode.GetErrorDescription();
                dto.ErrorCode = result.Exception.ErrorCode.GetErrorCode();

                if (result.Exception.ErrorCode == ErrorCodes.ValidationError)
                {
                    return StatusCode(400, dto);
                }
                
            }

            return StatusCode(500, dto);
        }

    }
}
