using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Mutations.Inputs
{
    public record CreateUserSettingSelfInput(
        string UserId,
        bool IsPrivate,
        bool ReceiveNotifications,
        bool ShowActivityStatus
    );
}
