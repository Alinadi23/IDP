using IDP.Core.ApplicationService.Common.Enums;

namespace IDP.EndPoints.WebAPI.Common.Mapping
{
    public static class ErrorCodeHttpMapping
    {
        public static int ToHttpStatus(this ApplicationResultState state)
            => state switch
            {
                ApplicationResultState.Ok => StatusCodes.Status200OK,
                ApplicationResultState.NotFound => StatusCodes.Status404NotFound,
                ApplicationResultState.ValidationError => StatusCodes.Status400BadRequest,
                ApplicationResultState.BusinessFault => StatusCodes.Status400BadRequest,
                ApplicationResultState.Unauthorized => StatusCodes.Status401Unauthorized,
                ApplicationResultState.Exception => StatusCodes.Status500InternalServerError,
                _ => StatusCodes.Status500InternalServerError
            };
    }
}
