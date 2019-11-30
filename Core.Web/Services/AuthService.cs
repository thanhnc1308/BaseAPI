using Core.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Web
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDistributedCache _cache;
        private SessionData _sessionData = null;

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

        public Guid GetDatabaseId()
        {
            //return Guid.Parse(_httpContextAccessor.HttpContext.Request.Items[Keys.HeaderUserId]);
            return Guid.Empty;
        }

        public string GetUserName()
        {
            //return _httpContextAccessor.HttpContext.Request.Items[Keys.HeaderUserId];
            return string.Empty;
        }

        public string GetSessionKey()
        {
            //return _httpContextAccessor.HttpContext.Request.Items[Keys.HeaderUserId];
            return string.Empty;
        }

        public SessionData GetSessionData(string sessionKey = "")
        {
            if (_sessionData != null)
            {
                return _sessionData;
            }

            SessionData sessionData = null;
            if (string.IsNullOrEmpty(sessionKey))
            {
                sessionKey = GetSessionKey();
            }

            if (!string.IsNullOrEmpty(sessionKey))
            {
                var tempSessionData = _cache.GetString(sessionKey);
                if (!string.IsNullOrWhiteSpace(tempSessionData))
                {
                    sessionData = Converter.Deserialize<SessionData>(tempSessionData);
                    _sessionData = sessionData;
                    return sessionData;
                }
            }
            return null;
        }

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
