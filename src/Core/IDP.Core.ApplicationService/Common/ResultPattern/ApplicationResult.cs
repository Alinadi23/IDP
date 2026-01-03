using IDP.Core.ApplicationService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Core.ApplicationService.Common.ResultPattern
{
    public sealed class ApplicationResult<T> : IApplicationResult
    {
        public bool IsSuccess => State == ApplicationResultState.Ok;
        public ApplicationResultState State { get; }
        public List<Error> Errors { get; set; }
        public T? Data { get; }
        object? IApplicationResult.Data => Data;
        public string? Message { get; }

        public ApplicationResult(ApplicationResultState state, T? data = default, string? message = null, List<Error> errors = null)
        {
            State = state;
            Data = data;
            Message = message;
            Errors?.AddRange(errors);
        }

        public static ApplicationResult<T> Success(T data)
            => new ApplicationResult<T>(ApplicationResultState.Ok, data);


        public static ApplicationResult<T> Fail(ApplicationResultState state, string? message = null)
            => new ApplicationResult<T>(state, default, message);

        public static ApplicationResult<T> Fail(ApplicationResultState state, string? message = null, List<Error> errors = null)
            => new ApplicationResult<T>(state, default, message, errors);

    }
}

