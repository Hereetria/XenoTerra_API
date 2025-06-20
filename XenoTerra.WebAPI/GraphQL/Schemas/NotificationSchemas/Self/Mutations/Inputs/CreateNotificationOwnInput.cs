using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations.Inputs
{
    public record CreateNotificationOwnInput(
        string Message,
        string? Image
    );
}
