using HotChocolate.Data.Filters;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries.Filters
{
    public class BlockUserOwnFilterType : FilterInputType<BlockUser>
    {
        protected override void Configure(IFilterInputTypeDescriptor<BlockUser> descriptor)
        {
        descriptor.Name("BlockUserOwnFilterInput");
        }
    }
}
