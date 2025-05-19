using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events.Types
{
    public class SavedPostAdminCreatedEventType : ObjectType<SavedPostAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostAdminCreatedEvent> descriptor)
        {
        }
    }
}