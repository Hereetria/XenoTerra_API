using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events.Types
{
    public class SavedPostSelfDeletedEventType : ObjectType<SavedPostSelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostSelfDeletedEvent> descriptor)
        {
        }
    }
}