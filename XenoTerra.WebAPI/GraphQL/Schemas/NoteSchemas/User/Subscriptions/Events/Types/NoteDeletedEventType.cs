using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events.Types
{
    public class NoteDeletedEventType : ObjectType<NoteDeletedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteDeletedSelfEvent> descriptor)
        {
        }
    }
}