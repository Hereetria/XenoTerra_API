using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Queries.Paginations
{
    public class ViewStoryEdge
    {
        public ResultViewStoryWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
