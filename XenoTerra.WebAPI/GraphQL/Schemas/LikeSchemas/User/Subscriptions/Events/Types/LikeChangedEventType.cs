using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events.Types
{
    public class LikeChangedEventType : ObjectType<LikeChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeChangedSelfEvent> descriptor)
        {
        }
    }
}
