﻿using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class BlockUserEdge
    {
        public ResultBlockUserWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
