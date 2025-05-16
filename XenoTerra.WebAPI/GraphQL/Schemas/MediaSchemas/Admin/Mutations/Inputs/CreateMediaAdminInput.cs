using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Mutations.Inputs
{
    public record CreateMediaAdminInput(
        string PhotoUrl,
        string UserId
    );
}
