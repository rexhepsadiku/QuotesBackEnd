using Microsoft.AspNetCore.Mvc;
using Quotes.API.Controllers.Base.Attributes;
using Quotes.Application.Wrappers;

namespace Quotes.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeApi]
    public class BaseApiController : ControllerBase
    {
        protected ActionResult HandleResult<T>(ApiResponse<T> result)
        {
            if (result == null) return NotFound();

            if (result.IsSuccess && result.Data != null)
                return Ok(result);

            if (result.IsSuccess && result.Data == null)
                return NotFound();

            return BadRequest(result);
        }
    }
}
