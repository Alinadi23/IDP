using IDP.Core.ApplicationService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Core.ApplicationService.Common.DTOs
{
    public class BaseResponseModel<T>
    {
        public T? Data { get; set; }
        public ApplicationResultState State { get; set; }
        public string? Message { get; set; }
    }
}
