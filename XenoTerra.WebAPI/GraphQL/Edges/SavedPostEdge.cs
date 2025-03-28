using XenoTerra.DTOLayer.Dtos.SavedPostDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class SavedPostEdge
    {
        public ResultSavedPostWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
