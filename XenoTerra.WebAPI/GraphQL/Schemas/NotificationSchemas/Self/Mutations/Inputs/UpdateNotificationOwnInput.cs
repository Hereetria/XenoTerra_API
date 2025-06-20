using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations.Inputs
{
    public record UpdateNotificationOwnInput(
        string NotificationId,
        string? Message,
        string? Image
    );
}
