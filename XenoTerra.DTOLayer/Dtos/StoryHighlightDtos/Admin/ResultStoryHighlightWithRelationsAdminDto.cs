using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.StoryHighlightAdminDtos.Admin
{
    public class ResultStoryHighlightWithRelationsAdminDto
    {
        public Guid StoryId { get; init; }
        public Guid HighlightId { get; init; }
        public ResultStoryAdminDto Story { get; set; } = new();
        public ResultHighlightAdminDto Highlight { get; set; } = new();
    }
}
