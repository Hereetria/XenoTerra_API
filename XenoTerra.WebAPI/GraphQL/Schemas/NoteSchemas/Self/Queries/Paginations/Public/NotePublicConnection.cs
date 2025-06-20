using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Paginations.Public
{
    public class NotePublicConnection(
        IReadOnlyList<Edge<ResultNotePublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultNotePublicDto>(edges, pageInfo, totalCount)
    {
    }
}
