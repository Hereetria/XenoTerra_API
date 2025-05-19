using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Queries.Paginations
{
    public class UserSettingAdminConnection(
        IReadOnlyList<Edge<ResultUserSettingWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultUserSettingWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
