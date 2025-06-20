using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Mutations.Payloads.Types
{
    public class CreateLikeOwnPayloadType : ObjectType<CreateStoryLikeOwnPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateStoryLikeOwnPayload> descriptor)
        {
        }
    }
}
