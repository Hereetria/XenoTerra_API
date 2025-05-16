using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events.Types
{
    public class LikeCreatedEventType : ObjectType<LikeCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeCreatedSelfEvent> descriptor)
        {
        }
    }
}
