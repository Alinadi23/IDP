using IDP.Core.ApplicationService.Common.ResultPattern;
using IDP.Core.ApplicationService.Users.DTOs.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Core.ApplicationService.Common.Interfaces
{
    public interface ICredentialService
    {
        public Task<ApplicationResult<RegisterResponse>> Register(RegisterRequest request);
    }
}
