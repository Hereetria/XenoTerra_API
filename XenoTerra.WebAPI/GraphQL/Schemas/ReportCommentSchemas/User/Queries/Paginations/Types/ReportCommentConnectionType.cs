using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Paginations.Types
{
    public class ReportCommentConnectionType : ObjectType<ReportCommentConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
