using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Mutations.Inputs
{
    public record UpdateUserSettingSelfInput(
        string UserSettingId,
        string? UserId,
        bool? IsPrivate,
        bool? ReceiveNotifications,
        bool? ShowActivityStatus
    );
}
