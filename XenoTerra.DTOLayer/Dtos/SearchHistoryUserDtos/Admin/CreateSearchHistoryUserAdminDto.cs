using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos.Admin
{
    public class CreateSearchHistoryUserAdminDto
    {
        public Guid SearchHistoryId { get; set; }
        public Guid UserId { get; set; }
    }
}
