using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Queries.Paginations
{
    public class UserSettingAdminConnection(
        IReadOnlyList<Edge<ResultUserSettingWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultUserSettingWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
