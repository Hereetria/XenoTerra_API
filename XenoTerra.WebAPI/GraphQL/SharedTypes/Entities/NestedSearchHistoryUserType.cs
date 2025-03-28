using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedSearchHistoryUserType : ObjectType<ResultSearchHistoryUserDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSearchHistoryUserDto> descriptor)
        {
            descriptor.Field(f => f.SearchHistoryId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.UserId)
                .Type<NonNullType<IdType>>();
        }
    }
}
