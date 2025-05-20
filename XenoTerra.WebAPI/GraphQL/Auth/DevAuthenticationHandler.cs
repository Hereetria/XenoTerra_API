using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace XenoTerra.WebAPI.GraphQL.Auth
{
    public class DevAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public DevAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock) { }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"), // örnek userId
            new Claim(ClaimTypes.Name, "devuser"),
            new Claim(ClaimTypes.Email, "devuser@example.com"),
            new Claim(ClaimTypes.Role, "Admin") // veya Visitor, User
        };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }

}
