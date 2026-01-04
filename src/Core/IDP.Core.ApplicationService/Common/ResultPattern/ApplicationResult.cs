using IDP.Core.ApplicationService.Common.Enums;
using IDP.Core.ApplicationService.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Core.ApplicationService.Common.ResultPattern
{
    public sealed class ApplicationResult : ApplicationResultBase
    {
        private ApplicationResult(
            ApplicationResultState state,
            string? message = null,
            IReadOnlyList<Error>? errors = null)
            : base(state, message, errors)
        {
        }

        public static ApplicationResult Success()
            => new(ApplicationResultState.Ok);

        public static ApplicationResult Fail(
            ApplicationResultState state,
            string? message = null,
            IReadOnlyList<Error>? errors = null)
            => new(state, message, errors);
    }

    public sealed class ApplicationResult<T> : ApplicationResultBase
    {
        public T? Value { get; }

        public override object? Data => Value;

        private ApplicationResult(
            ApplicationResultState state,
            T? value = default,
            string? message = null,
            IReadOnlyList<Error>? errors = null)
            : base(state, message, errors)
        {
            Value = value;
        }

        public static ApplicationResult<T> Success(T value)
            => new(ApplicationResultState.Ok, value, GeneralResource.OpeationSuccess);

        public static ApplicationResult<T> Fail(
            ApplicationResultState state,
            string? message = null,
            IReadOnlyList<Error>? errors = null)
            => new(state, default, message, errors);
    }
}

