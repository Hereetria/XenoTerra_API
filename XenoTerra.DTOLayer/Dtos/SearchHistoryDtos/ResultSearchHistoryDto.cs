using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryDtos
{
    public record class ResultSearchHistoryDto
    {
        public Guid SearchHistoryId { get; init; }
        public Guid UserId { get; init; }
        public DateTime SearchedAt { get; init; }
    }
}
