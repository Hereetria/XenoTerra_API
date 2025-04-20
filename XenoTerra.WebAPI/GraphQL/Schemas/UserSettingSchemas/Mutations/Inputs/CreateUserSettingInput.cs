using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Mutations.Inputs
{
    public record CreateUserSettingInput(
        string UserId,
        bool IsPrivate,
        bool ReceiveNotifications,
        bool ShowActivityStatus,
        [property: DateField] string LastUpdated
    );
}
