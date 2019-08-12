using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Base.Core
{
    public class Converter
    {
        private static readonly DateFormatHandling dateFormatHandling = DateFormatHandling.IsoDateFormat;
        private static readonly DateTimeZoneHandling dateTimeZoneHandling = DateTimeZoneHandling.Local;
        private static readonly string dateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";
        private static readonly NullValueHandling nullValueHandling = NullValueHandling.Include;
        private static readonly ReferenceLoopHandling referenceLoopHandling = ReferenceLoopHandling.Ignore;

        #region json
        public static JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings()
            {
                DateFormatHandling = dateFormatHandling,
                DateTimeZoneHandling = dateTimeZoneHandling,
                DateFormatString = dateFormatString,
                NullValueHandling = nullValueHandling,
                ReferenceLoopHandling = referenceLoopHandling
            };
        }

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, GetJsonSerializerSettings());
        }

        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, GetJsonSerializerSettings());
        }

        public static object Deserialize(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type, GetJsonSerializerSettings());
        }
        #endregion

        #region Base64
        public static string Base64Encode(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(text));
        }

        public static string Base64Decode(string base64Text)
        {
            if (string.IsNullOrWhiteSpace(base64Text))
            {
                return string.Empty;
            }
            return UTF8Encoding.UTF8.GetString(Convert.FromBase64String(base64Text));
        }
        #endregion

        #region SHA
        public static string SHA256Hash(string text)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();
            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }
        #endregion

        #region HTML Encode
        public static string UrlEncode(string url)
        {
            return WebUtility.UrlEncode(url);
        }

        public static string UrlDecode(string url)
        {
            return WebUtility.UrlDecode(url);
        }
        #endregion
    }
}
