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
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<UserService> _logger;

        public UserService(ICredentialTypeFactory credentialTypeFactory, ILogger<UserService> logger)
        {
            _credentialTypeFactory = credentialTypeFactory;
            _logger = logger;
        }

        public async Task<ApplicationResult<RegisterResponse>> Register(RegisterRequest request)
        {
            try
            {
                _logger.LogInformation("UserService.Register, Credential: {UserId}", request?.ViewModel?.Credential);
                var response = new BaseResponseModel<LoginResponse>();
                var credentialService = _credentialTypeFactory.GetType(request.ViewModel.CredentialType.Value);
                var registerResult = await credentialService.Register(request);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "UserService.Register, Exception : ");
                return ApplicationResult<RegisterResponse>.Fail(ApplicationResultState.Exception, GeneralResource.OperationFailed);
            }






            return ApplicationResult<RegisterResponse>.Success(null);
        }
    }
}
