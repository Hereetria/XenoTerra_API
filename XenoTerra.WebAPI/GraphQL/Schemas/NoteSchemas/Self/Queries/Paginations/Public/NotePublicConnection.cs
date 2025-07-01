using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Paginations.Public
{
    public class NotePublicConnection(
        IReadOnlyList<Edge<ResultNoteWithRelationsPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultNoteWithRelationsPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
