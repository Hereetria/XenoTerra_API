using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryDtos
{
    public class ResultSearchHistoryDto
    {
        public Guid SearchHistoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime SearchedAt { get; set; }
    }
}
