using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web
{
    public interface IAuthService
    {
        Guid GetUserId();
        string GetHeaderUserId();
        UserInfo GetCurrentUser();
    }
}
