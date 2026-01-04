using IDP.Core.ApplicationService.Common.Enums;
using IDP.Core.ApplicationService.Common.Interfaces;
using IDP.Core.ApplicationService.Common.Services.Credentials;
using IDP.Core.ApplicationService.Users.Interfaces;
using IDP.Core.Domain.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Core.ApplicationService.Common.Services.Factory
{
    public class CredentialTypeFactory : ICredentialTypeFactory, IApplicationService
    {
        private readonly IReadOnlyCollection<ICredentialService> _services;

        public CredentialTypeFactory(IEnumerable<ICredentialService> services)
        {
            _services = services.ToList();
        }

        public ICredentialService GetType(CredentialType type)
        {
            var service = _services.FirstOrDefault(s => s.Type == type);

            if (service is null)
                throw new Exception($"Credential type '{type}' is not supported");

            return service;
        }
    }
}
