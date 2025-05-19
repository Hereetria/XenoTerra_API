using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations.Inputs
{
    public record CreateNotificationSelfInput(
        string Message,
        string? Image
    );
}
