using XenoTerra.DTOLayer.Dtos.ViewStoryAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries.Paginations.Own
{
    public class ViewStoryOwnEdge
    {
        public ResultViewStoryWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
