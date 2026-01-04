using IDP.Core.ApplicationService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Core.ApplicationService.Common.ResultPattern
{
    public abstract class ApplicationResultBase : IApplicationResult
    {
        public bool IsSuccess => State == ApplicationResultState.Ok;
        public ApplicationResultState State { get; }
        public string? Message { get; }
        public IReadOnlyList<Error>? Errors { get; }

        public virtual object? Data => null;

        protected ApplicationResultBase(
            ApplicationResultState state,
            string? message = null,
            IReadOnlyList<Error>? errors = null)
        {
            State = state;
            Message = message;
            Errors = errors;
        }
    }
}
