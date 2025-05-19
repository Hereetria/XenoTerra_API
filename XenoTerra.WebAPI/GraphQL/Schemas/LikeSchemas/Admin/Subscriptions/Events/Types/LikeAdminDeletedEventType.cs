using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events.Types
{
    public class LikeAdminDeletedEventType : ObjectType<LikeAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeAdminDeletedEvent> descriptor)
        {
        }
    }
}
