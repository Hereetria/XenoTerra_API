using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events.Types
{
    public class SavedPostUpdatedEventType : ObjectType<SavedPostUpdatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostUpdatedSelfEvent> descriptor)
        {
        }
    }
}