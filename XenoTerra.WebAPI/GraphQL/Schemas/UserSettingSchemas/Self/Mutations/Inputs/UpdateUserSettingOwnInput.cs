using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Mutations.Inputs
{
    public record UpdateUserSettingOwnInput(
        string UserSettingId,
        bool? IsPrivate,
        bool? ReceiveNotifications,
        bool? ShowActivityStatus
    );
}
