using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events.Types
{
    public class NoteSelfChangedEventType : ObjectType<NoteSelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteSelfChangedEvent> descriptor)
        {
        }
    }
}