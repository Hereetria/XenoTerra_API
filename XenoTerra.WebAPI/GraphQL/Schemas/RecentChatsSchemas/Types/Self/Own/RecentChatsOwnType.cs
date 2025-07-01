using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Types.Self.Own
{
    public class RecentChatsOwnType : ObjectType<ResultRecentChatsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultRecentChatsOwnDto> descriptor)
        {
            descriptor.Name("ResultRecentChatsOwn");
        }
    }
}
