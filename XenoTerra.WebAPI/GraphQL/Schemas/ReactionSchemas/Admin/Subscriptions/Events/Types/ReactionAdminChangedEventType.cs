using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events.Types
{
    public class ReactionAdminChangedEventType : ObjectType<ReactionAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionAdminChangedEvent> descriptor)
        {
        }
    }
}