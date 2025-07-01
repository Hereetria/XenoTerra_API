using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Types.Admin
{
    public class RecentChatsAdminType : ObjectType<ResultRecentChatsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultRecentChatsAdminDto> descriptor)
        {
            descriptor.Name("ResultRecentChatsAdmin");
        }
    }
}
