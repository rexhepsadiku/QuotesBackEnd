using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Quotes.Domain.Constants.Identity;
using System.Net;
using System.Reflection;

namespace Quotes.API.Controllers.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeApiAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public AuthorizeApiAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (HasAnnonymouseAttribute(context)) return;

            var roleClaim = context.HttpContext.User.Claims.Where(x => x.Type == UserClaimsEnum.Role).Select(x => x.Value).FirstOrDefault();
            if (roleClaim == null)
            {
                SetContextResponse(context, "Unauthorized", HttpStatusCode.Unauthorized);
                return;
            }
            CheckWithRole(roleClaim, context);
        }

        private static bool HasAnnonymouseAttribute(AuthorizationFilterContext context)
        {
            MethodInfo method = (context.ActionDescriptor as ControllerActionDescriptor).MethodInfo;
            if (method.GetCustomAttribute(typeof(AllowAnonymousAttribute), false) != null) return true;
            else return false;
        }

        private void CheckWithRole(string roleName, AuthorizationFilterContext context)
        {
            if (_roles.Any() && !_roles.Contains(roleName)) SetContextResponse(context, "You don't have permission for this", HttpStatusCode.Forbidden);
        }

        private static void SetContextResponse(AuthorizationFilterContext context, string message, HttpStatusCode statusCode)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.Result = new JsonResult(new { message = message });
            context.HttpContext.Response.StatusCode = (int)statusCode;
        }
    }
}
