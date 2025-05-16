using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events.Types
{
    public class ReactionUpdatedEventType : ObjectType<ReactionUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionUpdatedAdminEvent> descriptor)
        {
        }
    }
}