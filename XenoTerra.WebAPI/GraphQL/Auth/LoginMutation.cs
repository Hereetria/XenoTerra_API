using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Auth.Inputs;
using XenoTerra.WebAPI.GraphQL.Auth.Payloads;
using XenoTerra.WebAPI.GraphQL.Auth.Services;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Auth
{
    public class LoginMutation
    {
        public async Task<LoginPayload> LoginAsync(
            [Service] IAuthService authService,
            [Service] IValidator<LoginInput> inputValidator,
            LoginInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(LoginInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);
            return await authService.LoginAsync(input);
        }
    }
}
