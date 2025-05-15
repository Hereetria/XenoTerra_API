using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Queries.Filters
{
    public class MediaFilterType : FilterInputType<Media>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Media> descriptor)
        {
        }
    }
}
