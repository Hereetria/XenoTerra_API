using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events.Types
{
    public class SavedPostSelfChangedEventType : ObjectType<SavedPostSelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostSelfChangedEvent> descriptor)
        {
        }
    }
}