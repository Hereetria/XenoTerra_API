using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.UserPostTagAdminDtos.Admin
{
    public class CreateUserPostTagAdminDto
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }
}
