using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events.Types
{
    public class LikeDeletedEventType : ObjectType<LikeDeletedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeDeletedSelfEvent> descriptor)
        {
        }
    }
}
