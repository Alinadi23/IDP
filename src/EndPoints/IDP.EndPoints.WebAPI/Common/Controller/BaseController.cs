using IDP.Core.ApplicationService.Common.ResultPattern;
using IDP.EndPoints.WebAPI.Common.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDP.EndPoints.WebAPI.Common.Controller
{
    public class BaseController : ControllerBase
    {
        protected IActionResult ActionResult<T>(T serviceResult)
        {
            if (serviceResult is null)
                return NotFound();

            if (serviceResult is IApplicationResult appResult)
            {
                var statusCode = appResult.State.ToHttpStatus();
                return new ObjectResult(new
                {
                    state = appResult.State,
                    data = appResult.Data,
                    message = appResult.Message,
                    errors = appResult.IsSuccess ? null : appResult.Errors
                })
                {
                    StatusCode = statusCode
                };
            }

            return Ok(serviceResult);
        }
    }
}
