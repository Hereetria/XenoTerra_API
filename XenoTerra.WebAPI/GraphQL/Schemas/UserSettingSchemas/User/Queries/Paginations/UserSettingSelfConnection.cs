using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Queries.Paginations
{
    public class UserSettingSelfConnection(
        IReadOnlyList<Edge<ResultUserSettingWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultUserSettingWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
