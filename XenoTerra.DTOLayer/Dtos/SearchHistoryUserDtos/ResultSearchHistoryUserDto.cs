using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos
{
    public record ResultSearchHistoryUserDto(
        Guid SearchHistoryId,
        Guid UserId
    );
}
