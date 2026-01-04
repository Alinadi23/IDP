using IDP.Core.ApplicationService.Common.Enums;
using IDP.Core.ApplicationService.Common.Helpers;
using IDP.Core.ApplicationService.Common.Interfaces;
using IDP.Core.ApplicationService.Common.ResultPattern;
using IDP.Core.ApplicationService.Resources;
using IDP.Core.ApplicationService.Users.DTOs.Register;
using IDP.Core.ApplicationService.Users.Interfaces;
using IDP.Core.Domain.Users.Entities;
using IDP.Core.Domain.Users.Enums;
using IDP.Core.Domain.Users.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IDP.Core.ApplicationService.Common.Services.Credentials
{
    public class EmailCredentialService : ICredentialService, IApplicationService
    {
        public CredentialType Type => CredentialType.Email;

        private readonly IUserRepository _userRepository;

        public EmailCredentialService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationResult<RegisterResponse>> Register(RegisterRequest request)
        {
            var viewModel = request.ViewModel;

            if (await _userRepository.ExistsAsync(viewModel.Credential))
            {
                return ApplicationResult<RegisterResponse>
                    .Fail(ApplicationResultState.ValidationError, GeneralResource.DuplicateUser);
            }

            var hasher = new PasswordHasher<object>();
            var passwordHash = hasher.HashPassword(null, viewModel.Password);

            var credential = new UserCredential(
                username: viewModel.Credential,
                credentialType: CredentialType.Email,
                credentialDescription: EnumHelper.GetEnumDescription(CredentialType.Email),
                passwordHash: passwordHash,
                passwordExpiredAt: null);

            var user = new User(credential);

            await _userRepository.InsertAsync(user);
            await _userRepository.CommitAsync();

            return ApplicationResult<RegisterResponse>.Success(new RegisterResponse());

        }
    }
}
