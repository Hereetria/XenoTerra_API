using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events.Types
{
    public class ReactionDeletedEventType : ObjectType<ReactionDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionDeletedAdminEvent> descriptor)
        {
        }
    }
}