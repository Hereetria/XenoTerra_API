using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos
{
    public record class ResultSearchHistoryUserWithRelationsDto
    {
        public Guid SearchHistoryId { get; init; }
        public Guid UserId { get; init; }
        public ResultSearchHistoryDto SearchHistory { get; init; } = new();
        public ResultAppUserPrivateDto User { get; init; } = new();
    }
}
