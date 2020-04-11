using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace DummyPayService.Api
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly string MerchantIdHeaderName = "Merchant-Id";
        private readonly string SecretKeyHeaderName = "Seckret-Key";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                return;
            }

            if (IsUnauthorized(context.HttpContext.Request.Headers))
            {
                context.Result = new CustomUnauthorizedResult("Unauthorized, merchant-id or secret-key is null.");
            }
        }

        private bool IsUnauthorized(IHeaderDictionary headerDictionary)
        {
            return headerDictionary.TryGetValue(MerchantIdHeaderName, out var merhantId) &&
               headerDictionary.TryGetValue(SecretKeyHeaderName, out var secretKey)
                ? string.IsNullOrWhiteSpace(merhantId) || string.IsNullOrWhiteSpace(secretKey)
                : true;
        }

        public class CustomUnauthorizedResult : JsonResult
        {
            public CustomUnauthorizedResult(string message)
                : base(new CustomError(message))
            {
                StatusCode = StatusCodes.Status401Unauthorized;
            }
        }
        public class CustomError
        {
            public string Error { get; }

            public CustomError(string message)
            {
                Error = message;
            }
        }
    }
}
