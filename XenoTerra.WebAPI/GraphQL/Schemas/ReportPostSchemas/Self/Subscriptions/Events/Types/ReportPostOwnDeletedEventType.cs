using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events.Types
{
    public class ReportPostOwnDeletedEventType : ObjectType<ReportPostOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportPostOwnDeletedEvent> descriptor)
        {
        }
    }
}