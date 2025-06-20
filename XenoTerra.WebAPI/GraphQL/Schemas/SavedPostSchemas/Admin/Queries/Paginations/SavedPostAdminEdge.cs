using XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Queries.Paginations
{
    public class SavedPostAdminEdge
    {
        public ResultSavedPostWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
