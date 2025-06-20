using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Queries.Paginations.Own.Types
{
    public class ReportStoryOwnConnectionType : ObjectType<ReportStoryOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportStoryOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
