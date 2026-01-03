using IDP.Core.ApplicationService.Authentication.DTOs.Login;
using IDP.Core.ApplicationService.Common.DTOs;
using IDP.Core.ApplicationService.Common.Enums;
using IDP.Core.ApplicationService.Common.Interfaces;
using IDP.Core.ApplicationService.Common.ResultPattern;
using IDP.Core.ApplicationService.Resources;
using IDP.Core.ApplicationService.Users.DTOs.Register;
using IDP.Core.ApplicationService.Users.Interfaces;
using IDP.Core.Domain.Users.Entities;
using IDP.Core.Domain.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Core.ApplicationService.Users.Services
{
    public class UserService : IUserService, IApplicationService
    {
        private readonly ICredentialTypeFactory _credentialTypeFactory;

        public UserService(ICredentialTypeFactory credentialTypeFactory)
        {
            _credentialTypeFactory = credentialTypeFactory;
        }

        public async Task<ApplicationResult<RegisterResponse>> Register(RegisterRequest request)
        {
            var response = new BaseResponseModel<LoginResponse>();
            var credentialType = _credentialTypeFactory.GetType(request.ViewModel.CredentialType);
            var registerResult = await credentialType.Register(request);




            return ApplicationResult<RegisterResponse>.Success(null);
        }
    }
}
