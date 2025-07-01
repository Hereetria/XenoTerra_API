using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Types.Admin
{
    public class RecentChatsWithRelationsAdminType : ObjectType<ResultRecentChatsWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultRecentChatsWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultRecentChatsWithRelationsAdmin");
        }
    }
}
