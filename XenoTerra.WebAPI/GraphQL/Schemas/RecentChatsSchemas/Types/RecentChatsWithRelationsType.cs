using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Types
{
    public class RecentChatsWithRelationsType : ObjectType<ResultRecentChatsWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultRecentChatsWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultRecentChatsWithRelations");
        }
    }
}
