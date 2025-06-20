using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events.Types
{
    public class ReportPostOwnChangedEventType : ObjectType<ReportPostOwnChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportPostOwnChangedEvent> descriptor)
        {
        }
    }
}