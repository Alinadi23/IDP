using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Core.ApplicationService.Common.Enums
{
    public enum ApplicationResultState
    {
        Ok = 1,
        NotFound = 2,
        ValidationError = 3,
        BusinessFault = 4,
        Exception = 5,
        Unauthorized = 6
    }
}
