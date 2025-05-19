using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Subscriptions.Events.Types
{
    public class LikeSelfDeletedEventType : ObjectType<LikeSelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeSelfDeletedEvent> descriptor)
        {
        }
    }
}
