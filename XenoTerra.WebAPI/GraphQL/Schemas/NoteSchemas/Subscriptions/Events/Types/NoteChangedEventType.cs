namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Subscriptions.Events.Types
{
    public class NoteChangedEventType : ObjectType<NoteChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteChangedEvent> descriptor)
        {
        }
    }
}