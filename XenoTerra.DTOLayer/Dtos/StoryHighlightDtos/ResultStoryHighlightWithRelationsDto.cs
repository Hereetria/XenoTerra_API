using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.StoryHighlightDtos
{
    public record class ResultStoryHighlightWithRelationsDto
    {
        public Guid StoryId { get; init; }
        public Guid HighlightId { get; init; }
        public ResultStoryDto Story { get; init; } = new();
        public ResultHighlightDto Highlight { get; init; } = new();
    }
}
