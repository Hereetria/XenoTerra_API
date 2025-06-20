using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries.Paginations.Own
{
    public class UserSettingOwnConnection(
        IReadOnlyList<Edge<ResultUserSettingWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultUserSettingWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
