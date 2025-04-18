using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Types
{
    public class RecentChatsType : ObjectType<ResultRecentChatsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultRecentChatsDto> descriptor)
        {
            descriptor.Name("ResultRecentChats");
        }
    }
}
