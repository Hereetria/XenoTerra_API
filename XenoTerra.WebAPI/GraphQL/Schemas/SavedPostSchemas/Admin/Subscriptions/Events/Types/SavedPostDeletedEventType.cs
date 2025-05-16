using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events.Types
{
    public class SavedPostDeletedEventType : ObjectType<SavedPostDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostDeletedAdminEvent> descriptor)
        {
        }
    }
}