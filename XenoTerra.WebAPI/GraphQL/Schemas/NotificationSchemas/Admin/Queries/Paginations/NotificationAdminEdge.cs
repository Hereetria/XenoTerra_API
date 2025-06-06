﻿using XenoTerra.DTOLayer.Dtos.NotificationDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Queries.Paginations
{
    public class NotificationAdminEdge
    {
        public ResultNotificationWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
