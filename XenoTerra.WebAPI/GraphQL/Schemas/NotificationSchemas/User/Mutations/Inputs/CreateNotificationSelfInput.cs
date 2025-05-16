using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Mutations.Inputs
{
    public record CreateNotificationSelfInput(
        string UserId,
        string Message,
        string? Image
    );
}
