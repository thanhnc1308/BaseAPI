using Base.Core;
using Base.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Core
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public string GetHeaderUserId()
        {
            return _httpContextAccessor.HttpContext.Request.Headers[Keys.HeaderUserId];
        }

        public Guid GetUserId()
        {
            string userId = _httpContextAccessor.HttpContext.Items["UserId"].ToString();
            if (string.IsNullOrEmpty(userId))
            {
                return Guid.NewGuid();
            }
            else
            {
                return Guid.Parse(userId);
            }
        }

        // get information about current user
        public UserInfo GetCurrentUser()
        {
            string jsonPayload = GetAuthPayloadString();
            return Converter.Deserialize<UserInfo>(jsonPayload);
        }

        #region Private Method
        private string GetAuthPayloadString()
        {
            string authHeader = _httpContextAccessor.HttpContext.Request.Headers[Keys.HeaderAuthorization];
            string token = authHeader.Split(new char[] { ' ' })[1];
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token);
            return jsonToken.Payload.SerializeToJson();
        }

        private Dictionary<string, object> GetAuthPayload()
        {
            string authHeader = _httpContextAccessor.HttpContext.Request.Headers[Keys.HeaderAuthorization];
            string token = authHeader.Split(new char[] { ' ' })[1];
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token);
            return jsonToken.Payload;
        }
        #endregion
    }
}
