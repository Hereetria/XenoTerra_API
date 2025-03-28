using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.SavedPostDtos
{
    public record ResultSavedPostDto(
        Guid SavedPostId,
        Guid UserId,
        Guid PostId,
        DateTime SavedAt
    );
}
