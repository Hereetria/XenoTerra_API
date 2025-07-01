using XenoTerra.DTOLayer.Dtos.SavedPostDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries.Paginations.Own
{
    public class SavedPostOwnEdge
    {
        public ResultSavedPostWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
