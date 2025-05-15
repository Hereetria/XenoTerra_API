using XenoTerra.WebAPI.GraphQL.Auth.Inputs;
using XenoTerra.WebAPI.GraphQL.Auth.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Auth.Services
{
    public interface IAuthService
    {
        Task<RegisterPayload> RegisterAsync(RegisterInput? input);
        Task<LoginPayload> LoginAsync(LoginInput input);
    }
}
