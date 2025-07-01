using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Admin;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.StoryHighlightDtos.Admin
{
    public class ResultStoryHighlightWithRelationsAdminDto
    {
        public Guid StoryId { get; init; }
        public Guid HighlightId { get; init; }
        public ResultStoryAdminDto Story { get; set; } = new();
        public ResultHighlightAdminDto Highlight { get; set; } = new();
    }
}
