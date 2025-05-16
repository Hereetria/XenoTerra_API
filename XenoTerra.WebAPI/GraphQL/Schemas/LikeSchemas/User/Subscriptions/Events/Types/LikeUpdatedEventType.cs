using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events.Types
{
    public class LikeUpdatedEventType : ObjectType<LikeUpdatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeUpdatedSelfEvent> descriptor)
        {
        }
    }
}
