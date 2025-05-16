using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Mutations.Inputs
{
    public record UpdateNotificationAdminInput(
        string NotificationId,
        string? UserId,
        string? Message,
        string? Image
    );
}
