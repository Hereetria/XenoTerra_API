using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.ReportCommentQueries.Filters
{
    public class ReportCommentFilterType : FilterInputType<ReportComment>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ReportComment> descriptor)
        {
        }
    }
}
