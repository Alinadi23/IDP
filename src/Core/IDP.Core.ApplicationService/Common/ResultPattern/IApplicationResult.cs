using IDP.Core.ApplicationService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Core.ApplicationService.Common.ResultPattern
{
    public interface IApplicationResult
    {
        bool IsSuccess { get; }
        ApplicationResultState State { get; }
        public List<Error> Errors { get; set; }
        object? Data { get; }
        string? Message { get; }
    }
}
