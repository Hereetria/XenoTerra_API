using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events.Types
{
    public class SavedPostOwnCreatedEventType : ObjectType<SavedPostOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostOwnCreatedEvent> descriptor)
        {
        }
    }
}