using XenoTerra.DTOLayer.Dtos.SavedPostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries.Paginations
{
    public class SavedPostSelfEdge
    {
        public ResultSavedPostWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
