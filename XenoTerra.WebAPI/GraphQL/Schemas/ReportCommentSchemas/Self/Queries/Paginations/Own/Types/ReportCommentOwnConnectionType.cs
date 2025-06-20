using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Queries.Paginations.Own.Types
{
    public class ReportCommentOwnConnectionType : ObjectType<ReportCommentOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
