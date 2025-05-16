using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events.Types
{
    public class LikeCreatedEventType : ObjectType<LikeCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeCreatedAdminEvent> descriptor)
        {
        }
    }
}
