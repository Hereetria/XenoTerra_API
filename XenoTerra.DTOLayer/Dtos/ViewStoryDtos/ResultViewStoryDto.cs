using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.ViewStoryDtos
{
    public record class ResultViewStoryDto
    {
        public Guid ViewStoryId { get; init; }
        public Guid StoryId { get; init; }
        public Guid UserId { get; init; }
        public DateTime ViewedAt { get; init; }
    }
}
