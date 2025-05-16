using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Paginations.Types
{
    public class ReportCommentAdminConnectionType : ObjectType<ReportCommentAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
