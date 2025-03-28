using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedSearchHistoryType : ObjectType<ResultSearchHistoryDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSearchHistoryDto> descriptor)
        {
            descriptor.Field(f => f.SearchHistoryId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.UserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.SearchedAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
