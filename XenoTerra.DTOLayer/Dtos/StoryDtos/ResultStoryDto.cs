using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.StoryDtos
{
    public record ResultStoryDto(
        Guid StoryId,
        string Path,
        bool IsVideo,
        Guid UserId,
        DateTime CreatedAt
    );
}
