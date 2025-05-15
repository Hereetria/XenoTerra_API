using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations.Payloads.Types
{
    public class CreateRolePayloadType : ObjectType<CreateRolePayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateRolePayload> descriptor)
        {
        }
    }
}
