using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events.Types
{
    public class SavedPostSelfUpdatedEventType : ObjectType<SavedPostSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostSelfUpdatedEvent> descriptor)
        {
        }
    }
}