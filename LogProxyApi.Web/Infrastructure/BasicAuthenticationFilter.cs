using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace LogProxyApi.Web.Infrastructure
{
    public class BasicAuthenticationFilter : IAuthorizationFilter
    {
        public BasicAuthenticationFilter(string realm)
        {
            _realm = realm;
            if (string.IsNullOrWhiteSpace(_realm))
            {
                throw new ArgumentNullException(nameof(realm), @"Please provide a non-empty realm value.");
            }
        }
        private readonly string _realm = "My Realm";
        public  void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                string authHeader = context.HttpContext.Request.Headers["Authorization"];
                if (authHeader != null)
                {
                    var authHeaderValue = AuthenticationHeaderValue.Parse(authHeader);
                    if (authHeaderValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        if (ParseCredentials(authHeaderValue.Parameter, out string user, out string password) && IsAuthorizedUser(user, password))
                            return;
                    }
                }

                ReturnUnauthorizedResult(context);
            }
            catch 
            {
                ReturnUnauthorizedResult(context);
            }
        }

        private void ReturnUnauthorizedResult(AuthorizationFilterContext context)
        {
            context.HttpContext.Response.Headers["WWW-Authenticate"] = $"Basic realm=\"{_realm}\"";
            context.Result = new UnauthorizedResult();
        }

        private bool ParseCredentials(string token, out string user, out string password)
        {
            user = null;
            password = null;

            if (string.IsNullOrEmpty(token))
                return false;

            var decodeauthToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));

            var splittetToken = decodeauthToken.Split(':');
            if (splittetToken.Length == 0)
                return false;

            if (splittetToken.Length > 0)
                user = splittetToken[0];

            if (splittetToken.Length > 1)
                password = splittetToken[1];

            return true;
        }

        private static bool IsAuthorizedUser(string username, string password)
        {
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }
    }
}
