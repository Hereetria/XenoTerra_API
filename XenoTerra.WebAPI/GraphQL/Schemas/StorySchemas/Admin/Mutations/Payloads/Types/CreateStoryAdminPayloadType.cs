using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Payloads.Types
{
    public class CreateStoryAdminPayloadType : ObjectType<CreateStoryAdminPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateStoryAdminPayload> descriptor)
        {
        }
    }
}
