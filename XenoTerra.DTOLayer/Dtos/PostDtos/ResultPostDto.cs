using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.PostDtos
{
    public record ResultPostDto(
        Guid PostId,
        string Caption,
        string Path,
        bool IsVideo,
        Guid UserId,
        DateTime CreatedAt
    );
}
