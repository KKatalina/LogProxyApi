using Microsoft.AspNetCore.Mvc;
using System;

namespace LogProxyApi.Web.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BasicAuthenticationAttribute : TypeFilterAttribute
    {
        public BasicAuthenticationAttribute(string realm = @"My Realm") : base(typeof(BasicAuthenticationFilter))
        {
            Arguments = new object[] { realm };
        }
    }
}
