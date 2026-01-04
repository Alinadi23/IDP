using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Core.ApplicationService.Common.Interfaces.CurrentService
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
    }
}
