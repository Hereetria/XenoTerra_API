using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Payloads.Types
{
    public class CreateStoryPayloadType : ObjectType<CreateStoryPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateStoryPayload> descriptor)
        {
        }
    }
}
