using HotChocolate.Data.Filters;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries.Filters
{
    public class BlockUserFilterType : FilterInputType<BlockUser>
    {
        protected override void Configure(IFilterInputTypeDescriptor<BlockUser> descriptor)
        {
        }
    }
}
