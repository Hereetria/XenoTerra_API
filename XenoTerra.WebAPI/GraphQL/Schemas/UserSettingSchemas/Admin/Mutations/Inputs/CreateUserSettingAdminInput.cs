using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Mutations.Inputs
{
    public record CreateUserSettingAdminInput(
        string UserId,
        bool IsPrivate,
        bool ReceiveNotifications,
        bool ShowActivityStatus
    );
}
