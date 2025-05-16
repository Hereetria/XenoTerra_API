using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events.Types
{
    public class ReactionChangedEventType : ObjectType<ReactionChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionChangedAdminEvent> descriptor)
        {
        }
    }
}