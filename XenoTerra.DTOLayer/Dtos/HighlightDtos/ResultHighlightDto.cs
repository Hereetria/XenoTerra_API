﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.HighlightDtos
{
    public record ResultHighlightDto
    {
        public Guid HighlightId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string ProfilePicturePath { get; init; } = string.Empty;
    }
}
