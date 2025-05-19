using HotChocolate.Data.Filters;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries.Filters
{
    public class BlockUserAdminFilterType : FilterInputType<BlockUser>
    {
        protected override void Configure(IFilterInputTypeDescriptor<BlockUser> descriptor)
        {
        descriptor.Name("BlockUserAdminFilterInput");
        }
    }
}
