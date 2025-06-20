using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events.Types
{
    public class NoteOwnChangedEventType : ObjectType<NoteOwnChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteOwnChangedEvent> descriptor)
        {
        }
    }
}