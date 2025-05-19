using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events.Types
{
    public class NoteSelfUpdatedEventType : ObjectType<NoteSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteSelfUpdatedEvent> descriptor)
        {
        }
    }
}