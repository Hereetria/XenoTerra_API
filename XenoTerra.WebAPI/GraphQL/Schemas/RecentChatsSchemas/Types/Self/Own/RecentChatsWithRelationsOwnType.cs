using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Types.Self.Own
{
    public class RecentChatsWithRelationsOwnType : ObjectType<ResultRecentChatsWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultRecentChatsWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultRecentChatsWithRelationsOwn");
        }
    }
}
