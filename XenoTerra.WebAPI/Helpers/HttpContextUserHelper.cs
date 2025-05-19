using System.Security.Claims;

namespace XenoTerra.WebAPI.Helpers
{
    public static class HttpContextUserHelper
    {
        public static Guid GetMyUserId(HttpContext? httpContext)
        {
            ArgumentNullException.ThrowIfNull(httpContext, nameof(httpContext));

            var userIdClaim = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim is null || string.IsNullOrWhiteSpace(userIdClaim.Value))
            {
                throw GraphQLExceptionFactory.Create(
                    "User ID claim not found in token.",
                    ["You must be logged in to perform this action.", "Token does not contain a valid user identifier."],
                    "UNAUTHORIZED"
                );
            }

            if (!Guid.TryParse(userIdClaim.Value, out var userId))
            {
                throw GraphQLExceptionFactory.Create(
                    "User ID in token is not a valid GUID.",
                    ["Please log in again.", "Token may have been tampered with or expired."],
                    "UNAUTHORIZED"
                );
            }

            return userId;
        }
    }
}
