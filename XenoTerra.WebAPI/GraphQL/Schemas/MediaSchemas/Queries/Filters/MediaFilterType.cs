using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.MediaQueries.Filters
{
    public class MediaFilterType : FilterInputType<Media>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Media> descriptor)
        {
        }
    }
}
