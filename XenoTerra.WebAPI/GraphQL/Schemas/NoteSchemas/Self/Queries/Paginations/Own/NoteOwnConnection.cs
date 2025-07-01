using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Paginations.Own
{
    public class NoteOwnConnection(
        IReadOnlyList<Edge<ResultNoteWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultNoteWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
