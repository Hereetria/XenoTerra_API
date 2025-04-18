using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.NoteDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Queries.Paginations
{
    public class NoteConnection(
        IReadOnlyList<Edge<ResultNoteWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultNoteWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
