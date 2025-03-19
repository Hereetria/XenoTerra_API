using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.StoryHighlightDtos
{
    public class ResultStoryHighlightDto
    {
        public Guid StoryId { get; set; }
        public Guid HighlightId { get; set; }
    }
}
