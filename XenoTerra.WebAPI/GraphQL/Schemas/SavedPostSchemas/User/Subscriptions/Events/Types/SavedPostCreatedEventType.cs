using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events.Types
{
    public class SavedPostCreatedEventType : ObjectType<SavedPostCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostCreatedSelfEvent> descriptor)
        {
        }
    }
}