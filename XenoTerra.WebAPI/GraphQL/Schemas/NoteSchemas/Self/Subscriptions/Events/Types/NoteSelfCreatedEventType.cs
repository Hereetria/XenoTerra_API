using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events.Types
{
    public class NoteSelfCreatedEventType : ObjectType<NoteSelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteSelfCreatedEvent> descriptor)
        {
        }
    }
}