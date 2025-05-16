using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events.Types
{
    public class NoteUpdatedEventType : ObjectType<NoteUpdatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteUpdatedSelfEvent> descriptor)
        {
        }
    }
}