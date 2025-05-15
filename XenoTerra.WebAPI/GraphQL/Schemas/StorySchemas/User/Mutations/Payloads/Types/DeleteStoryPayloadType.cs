using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Payloads.Types
{
    public class DeleteStoryPayloadType : ObjectType<DeleteStoryPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteStoryPayload> descriptor)
        {
        }
    }
}
