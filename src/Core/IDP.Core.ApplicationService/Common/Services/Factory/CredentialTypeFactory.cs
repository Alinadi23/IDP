using IDP.Core.ApplicationService.Common.Enums;
using IDP.Core.ApplicationService.Common.Interfaces;
using IDP.Core.ApplicationService.Common.Services.Credentials;
using IDP.Core.ApplicationService.Users.Interfaces;
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
        public ICredentialService GetType(CredentialType? type)
        {
            switch (type)
            {
                case CredentialType.Email:
                    return new EmailCredentialService();
                default:
                    return null;
            }
        }
    }
}
