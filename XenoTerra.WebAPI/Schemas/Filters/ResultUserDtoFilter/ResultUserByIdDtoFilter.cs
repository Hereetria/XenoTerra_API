using HotChocolate.Data.Filters;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.Schemas.Filters.User
{
    public class ResultUserDtoFilter : FilterInputType<ResultUserDto>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ResultUserDto> descriptor)
        {
            descriptor.Ignore(c => c.Password);
            base.Configure(descriptor);
        }
    }
}
