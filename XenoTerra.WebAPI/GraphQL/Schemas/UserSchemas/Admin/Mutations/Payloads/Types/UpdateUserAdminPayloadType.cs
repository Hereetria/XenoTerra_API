using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Mutations.Payloads.Types
{
    public class UpdateUserAdminPayloadType : ObjectType<UpdateUserAdminPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<UpdateUserAdminPayload> descriptor)
        {
        }
    }
}
