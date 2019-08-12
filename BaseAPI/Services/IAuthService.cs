using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Core
{
    public interface IAuthService
    {
        Guid GetUserId();
        string GetHeaderUserId();
        UserInfo GetCurrentUser();
    }
}
