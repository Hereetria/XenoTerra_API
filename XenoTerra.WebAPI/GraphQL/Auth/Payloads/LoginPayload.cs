namespace XenoTerra.WebAPI.GraphQL.Auth.Payloads
{

    public record LoginPayload(string Token, DateTime ExpiresAt, Guid UserId, string UserName);
}
