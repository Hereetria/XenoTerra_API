﻿using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries.Paginations
{
    public class RecentChatsAdminEdge
    {
        public ResultRecentChatsWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
