using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.ViewStoryDtos
{
    public record ResultViewStoryDto(
        Guid ViewStoryId,
        Guid StoryId,
        Guid UserId,
        DateTime ViewedAt
    );
}
