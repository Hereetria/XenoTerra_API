using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Queries.Filters
{
    public class ReportCommentSelfFilterType : FilterInputType<ReportComment>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ReportComment> descriptor)
        {
        descriptor.Name("ReportCommentSelfFilterInput");
        }
    }
}
