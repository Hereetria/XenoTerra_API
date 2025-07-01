using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos.Admin
{
    public class ResultSearchHistoryUserWithRelationsAdminDto
    {
        public Guid SearchHistoryId { get; init; }
        public Guid UserId { get; init; }
        public ResultSearchHistoryAdminDto SearchHistory { get; set; } = new();
        public ResultAppUserAdminDto User { get; set; } = new();
    }
}
