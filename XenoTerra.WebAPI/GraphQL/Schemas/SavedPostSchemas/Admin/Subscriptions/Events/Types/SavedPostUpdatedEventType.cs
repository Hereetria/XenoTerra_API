using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events.Types
{
    public class SavedPostUpdatedEventType : ObjectType<SavedPostUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostUpdatedAdminEvent> descriptor)
        {
        }
    }
}