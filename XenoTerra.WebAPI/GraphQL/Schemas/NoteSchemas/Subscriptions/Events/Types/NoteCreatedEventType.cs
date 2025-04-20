namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Subscriptions.Events.Types
{
    public class NoteCreatedEventType : ObjectType<NoteCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteCreatedEvent> descriptor)
        {
        }
    }
}