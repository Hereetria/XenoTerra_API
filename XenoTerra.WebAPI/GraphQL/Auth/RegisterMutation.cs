using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Auth.Inputs;
using XenoTerra.WebAPI.GraphQL.Auth.Payloads;
using XenoTerra.WebAPI.GraphQL.Auth.Services;

namespace XenoTerra.WebAPI.GraphQL.Auth
{
    public class RegisterMutation
    {
        public async Task<RegisterPayload> RegisterAsync(
            [Service] IAuthService authService,
            RegisterInput? input)
        {
            return await authService.RegisterAsync(input);
        }
    }
}
