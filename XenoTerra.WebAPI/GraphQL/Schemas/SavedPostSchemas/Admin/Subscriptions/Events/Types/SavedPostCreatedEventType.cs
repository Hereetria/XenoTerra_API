using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events.Types
{
    public class SavedPostCreatedEventType : ObjectType<SavedPostCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostCreatedEvent> descriptor)
        {
        }
    }
}