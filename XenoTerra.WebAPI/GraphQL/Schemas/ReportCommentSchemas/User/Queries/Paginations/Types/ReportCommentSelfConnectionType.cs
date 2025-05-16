using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Paginations.Types
{
    public class ReportCommentSelfConnectionType : ObjectType<ReportCommentSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
