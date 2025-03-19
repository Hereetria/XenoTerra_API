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
    public class ResultStoryHighlightWithRelationsDto
    {
        public Guid StoryId { get; set; }
        public ResultStoryDto? Story { get; set; }

        public Guid HighlightId { get; set; }
        public ResultHighlightDto? Highlight { get; set; }
    }
}
