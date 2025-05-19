using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.NoteDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Paginations
{
    public class NoteSelfConnection(
        IReadOnlyList<Edge<ResultNoteWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultNoteWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
