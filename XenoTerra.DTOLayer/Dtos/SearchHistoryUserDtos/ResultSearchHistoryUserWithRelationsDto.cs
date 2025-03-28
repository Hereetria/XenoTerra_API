using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos
{
    public record ResultSearchHistoryUserWithRelationsDto(
        Guid SearchHistoryId,
        Guid UserId
    )
    {
        public ResultSearchHistoryDto? SearchHistory { get; set; }
        public ResultUserDto? User { get; set; }
    }
}
