using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events.Types
{
    public class LikeUpdatedEventType : ObjectType<LikeUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeUpdatedAdminEvent> descriptor)
        {
        }
    }
}
