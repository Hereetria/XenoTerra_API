using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events.Types
{
    public class SavedPostDeletedEventType : ObjectType<SavedPostDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostDeletedEvent> descriptor)
        {
        }
    }
}