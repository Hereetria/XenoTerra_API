using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos
{
    public class ResultSearchHistoryUserDto
    {
        public Guid SearchHistoryId { get; set; }
        public Guid UserId { get; set; }
    }
}
