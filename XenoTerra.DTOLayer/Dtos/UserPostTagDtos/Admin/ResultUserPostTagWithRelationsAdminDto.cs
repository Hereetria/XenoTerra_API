using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.PostDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Admin
{
    public class ResultUserPostTagWithRelationsAdminDto
    {
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public ResultPostAdminDto Post { get; set; } = new();
        public ResultAppUserAdminDto User { get; set; } = new();
    }
}
