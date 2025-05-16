using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events.Types
{
    public class LikeDeletedEventType : ObjectType<LikeDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeDeletedAdminEvent> descriptor)
        {
        }
    }
}
