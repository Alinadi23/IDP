using IDP.Core.ApplicationService.Common.Enums;
using IDP.Core.Domain.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Core.ApplicationService.Users.DTOs.Register
{
    public class RegisterViewModel
    {
        public string? Credential { get; set; }
        public CredentialType? CredentialType { get; set; }
        public string? Password { get; set; }
    }
}
