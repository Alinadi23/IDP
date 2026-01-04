using IDP.Core.ApplicationService.Common.Interfaces.CurrentService;
using IDP.Core.ApplicationService.Users.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace IDP.Core.ApplicationService.Common.Services.CurrentUser
{
    public class CurrentUserService : ICurrentUserService, IApplicationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? UserId =>
            _httpContextAccessor.HttpContext?
                .User?
                .FindFirst(ClaimTypes.NameIdentifier)?
                .Value;
    }
}
