using IDP.Core.ApplicationService.Common.Enums;

namespace IDP.Core.ApplicationService.Common.ResultPattern
{
    public sealed class Error
    {
        public string? Code { get; }
        public string? ErrorMessage { get; }

        public Error(string? code, string? errorMessage)
        {
            Code = code;
            ErrorMessage = errorMessage;
        }
    }
}
