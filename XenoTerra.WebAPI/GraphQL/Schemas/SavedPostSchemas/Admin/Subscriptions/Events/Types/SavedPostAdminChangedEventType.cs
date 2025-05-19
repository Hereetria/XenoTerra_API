using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events.Types
{
    public class SavedPostAdminChangedEventType : ObjectType<SavedPostAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostAdminChangedEvent> descriptor)
        {
        }
    }
}