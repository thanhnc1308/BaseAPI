using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Common
{
    [Serializable]
    public class UserInfo
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ShardInfo { get; set; }
        public string SessionId { get; set; }
        public Guid DatabaseId { get; set; }
        public string ConnectionString { get; set; }
    }

    [Serializable]
    public class SessionData
    {
        public UserInfo User { get; set; }
        public Guid DatabaseId { get; set; }
        public string ConnectionString { get; set; }
    }
}
