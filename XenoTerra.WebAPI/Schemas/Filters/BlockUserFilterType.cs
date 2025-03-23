using HotChocolate.Data.Filters;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.Schemas.Filters
{
    public class BlockUserFilterType : FilterInputType<ResultBlockUserWithRelationsDto>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ResultBlockUserWithRelationsDto> descriptor)
        {
            base.Configure(descriptor);
        }
    }
}
