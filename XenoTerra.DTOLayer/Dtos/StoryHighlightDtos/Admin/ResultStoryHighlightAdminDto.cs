using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.StoryHighlightAdminDtos.Admin
{
    public class ResultStoryHighlightAdminDto
    {
        public Guid StoryId { get; init; }
        public Guid HighlightId { get; init; }
    }
}
