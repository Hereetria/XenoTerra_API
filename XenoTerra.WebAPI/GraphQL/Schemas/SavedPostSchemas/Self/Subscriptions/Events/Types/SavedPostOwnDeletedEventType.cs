using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events.Types
{
    public class SavedPostOwnDeletedEventType : ObjectType<SavedPostOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostOwnDeletedEvent> descriptor)
        {
        }
    }
}