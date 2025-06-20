using XenoTerra.DTOLayer.Dtos.MessageAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries.Paginations
{
    public class MessageAdminEdge
    {
        public ResultMessageWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
