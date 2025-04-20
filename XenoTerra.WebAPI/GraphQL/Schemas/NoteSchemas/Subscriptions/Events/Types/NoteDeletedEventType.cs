namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Subscriptions.Events.Types
{
    public class NoteDeletedEventType : ObjectType<NoteDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteDeletedEvent> descriptor)
        {
        }
    }
}