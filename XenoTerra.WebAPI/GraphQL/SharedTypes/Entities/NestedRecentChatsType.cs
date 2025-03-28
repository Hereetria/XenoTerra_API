using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedRecentChatsType : ObjectType<ResultRecentChatsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultRecentChatsDto> descriptor)
        {
            descriptor.Field(f => f.RecentChatsId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.LastMessage)
                .Type<StringType>();

            descriptor.Field(f => f.UserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.LastMessageAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
