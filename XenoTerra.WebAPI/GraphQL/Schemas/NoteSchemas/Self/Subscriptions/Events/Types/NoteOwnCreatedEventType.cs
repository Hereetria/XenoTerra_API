using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events.Types
{
    public class NoteOwnCreatedEventType : ObjectType<NoteOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteOwnCreatedEvent> descriptor)
        {
        }
    }
}