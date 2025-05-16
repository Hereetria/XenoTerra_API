using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events.Types
{
    public class SavedPostChangedEventType : ObjectType<SavedPostChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostChangedAdminEvent> descriptor)
        {
        }
    }
}