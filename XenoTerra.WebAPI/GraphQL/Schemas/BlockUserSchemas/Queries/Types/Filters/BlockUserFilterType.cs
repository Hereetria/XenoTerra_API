using HotChocolate.Data.Filters;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries.Types.Filters
{
    public class BlockUserFilterType : FilterInputType<BlockUser>
    {
        protected override void Configure(IFilterInputTypeDescriptor<BlockUser> descriptor)
        {
            descriptor.Field(f => f.BlockUserId);
            descriptor.Field(f => f.BlockingUserId);
            descriptor.Field(f => f.BlockedUserId);
            descriptor.Field(f => f.BlockedAt);
        }
    }
}
