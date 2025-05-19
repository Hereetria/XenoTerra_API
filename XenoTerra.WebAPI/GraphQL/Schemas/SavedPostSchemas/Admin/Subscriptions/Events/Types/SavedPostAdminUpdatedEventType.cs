using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events.Types
{
    public class SavedPostAdminUpdatedEventType : ObjectType<SavedPostAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostAdminUpdatedEvent> descriptor)
        {
        }
    }
}