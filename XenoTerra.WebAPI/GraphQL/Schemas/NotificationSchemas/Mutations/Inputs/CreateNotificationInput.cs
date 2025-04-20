using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Mutations.Inputs
{
    public record CreateNotificationInput(
        string UserId,
        string Message,
        string? Image,
        [property: DateField] string CreatedAt
    );
}
