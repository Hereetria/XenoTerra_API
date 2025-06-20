using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.UserPostTagAdminDtos.Admin
{
    public class ResultUserPostTagAdminDto
    {
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
    }
}
