namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Subscriptions.Events.Types
{
    public class NoteUpdatedEventType : ObjectType<NoteUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteUpdatedEvent> descriptor)
        {
        }
    }
}