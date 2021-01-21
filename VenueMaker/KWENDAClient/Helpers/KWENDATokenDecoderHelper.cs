// install-package JWT
// Is called jwt.net
// Obsolete: install-package Microsoft.IdentityModel.Tokens

using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using System.Web.UI;

namespace KWENDA.Helpers
{
    public static class KWENDATokenDecoderHelper
    {
        private static string thesecret = "@uthenticati0n-15-a-queepart-0Fz3qur!ty";

        public static KWENDATokenJWTInfo DecodeToken(this string token, string secret = null)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                UtcDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

                string json = decoder.Decode(token, secret ?? thesecret, false);
                KWENDATokenJWTInfo jwtinfo = JsonConvert.DeserializeObject<KWENDATokenJWTInfo>(json);

                decoder.Decode(token, secret ?? thesecret, verify: true);

                return jwtinfo;

            }
            catch (TokenExpiredException)
            {
                throw new Exception("Inloggningen är för gammal.");
            }
            catch (SignatureVerificationException)
            {
                throw new Exception("Inloggningsinformationen är inte korrekt.");
            }

        }

        public static DateTime? UnixTimeStampToDateTime(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            double ts;
            if (!double.TryParse(value, out ts))
            {
                return null;
            }

            return UnixTimeStampToDateTime(ts);

        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;

        }

        public static int DateTimeToUnixTimeStamp(DateTime dt)
        {
            // Unix timestamp is seconds past epoch
            Int32 unixTimestamp = (Int32)(dt.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp;

        }

    } // class

}