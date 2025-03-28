using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryDtos
{
    public record ResultSearchHistoryDto(
        Guid SearchHistoryId,
        Guid UserId,
        DateTime SearchedAt
    );
}
