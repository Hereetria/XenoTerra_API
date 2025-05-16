using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events.Types
{
    public class NoteChangedEventType : ObjectType<NoteChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteChangedSelfEvent> descriptor)
        {
        }
    }
}