using HotChocolate.Data.Sorting;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.Schemas.Sorters
{
    public class BlockUserSortType : SortInputType<ResultBlockUserWithRelationsDto>
    {
        protected override void Configure(ISortInputTypeDescriptor<ResultBlockUserWithRelationsDto> descriptor)
        {
            base.Configure(descriptor);
        }
    }
}
