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
    public record ResultStoryHighlightWithRelationsDto(
        Guid StoryId,
        Guid HighlightId
    )
    {
        public ResultStoryDto? Story { get; set; }
        public ResultHighlightDto? Highlight { get; set; }
    }
}
