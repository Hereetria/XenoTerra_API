using XenoTerra.DTOLayer.Dtos.SavedPostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Queries.Paginations
{
    public class SavedPostEdge
    {
        public ResultSavedPostWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
