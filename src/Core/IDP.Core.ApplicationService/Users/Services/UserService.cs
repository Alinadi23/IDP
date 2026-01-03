using IDP.Core.ApplicationService.Authentication.DTOs.Login;
using IDP.Core.ApplicationService.Common.DTOs;
using IDP.Core.ApplicationService.Common.Enums;
using IDP.Core.ApplicationService.Common.ResultPattern;
using IDP.Core.ApplicationService.Resources;
using IDP.Core.ApplicationService.Users.DTOs;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationResult<LoginResponse>> Register(RegisterRequest request)
        {
            var response = new BaseResponseModel<LoginResponse>();
            var userExisted = await _userRepository.ExistsAsync(request.Email);
            if (userExisted) 
            {
                return ApplicationResult<LoginResponse>.Fail(ApplicationResultState.ValidationError, GeneralResource.DuplicateUser);
            }

            var user = new User
            {
                Username = request.Email,
                //PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password) 
            };

            return null;
        }
    }
}
