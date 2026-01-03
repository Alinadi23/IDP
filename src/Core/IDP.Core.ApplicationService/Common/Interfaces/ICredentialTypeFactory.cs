using IDP.Core.ApplicationService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Core.ApplicationService.Common.Interfaces
{
    public interface ICredentialTypeFactory
    {
        ICredentialService GetType(CredentialType? type);
    }
}
