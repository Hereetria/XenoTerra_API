using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events.Types
{
    public class LikeDeletedEventType : ObjectType<LikeDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeDeletedEvent> descriptor)
        {
        }
    }
}
