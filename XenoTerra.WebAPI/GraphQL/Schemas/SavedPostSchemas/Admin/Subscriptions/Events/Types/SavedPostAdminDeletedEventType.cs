using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events.Types
{
    public class SavedPostAdminDeletedEventType : ObjectType<SavedPostAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostAdminDeletedEvent> descriptor)
        {
        }
    }
}