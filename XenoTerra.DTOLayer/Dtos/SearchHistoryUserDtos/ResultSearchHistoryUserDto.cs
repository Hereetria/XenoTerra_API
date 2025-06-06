﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos
{
    public record class ResultSearchHistoryUserDto
    {
        public Guid SearchHistoryId { get; init; }
        public Guid UserId { get; init; }
    }
}
