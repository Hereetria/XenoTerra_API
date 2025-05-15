using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Filters
{
    public class ReportCommentFilterType : FilterInputType<ReportComment>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ReportComment> descriptor)
        {
        }
    }
}
