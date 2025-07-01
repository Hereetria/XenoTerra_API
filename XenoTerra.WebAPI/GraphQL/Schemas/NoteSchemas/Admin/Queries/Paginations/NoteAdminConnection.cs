using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.NoteDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Queries.Paginations
{
    public class NoteAdminConnection(
        IReadOnlyList<Edge<ResultNoteWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultNoteWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
