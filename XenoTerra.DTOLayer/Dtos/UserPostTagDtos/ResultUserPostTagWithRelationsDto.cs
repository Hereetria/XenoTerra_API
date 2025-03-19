using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.UserPostTagDtos
{
    public class ResultUserPostTagWithRelationsDto
    {
        public Guid PostId { get; set; }
        public ResultPostDto? Post { get; set; }

        public Guid UserId { get; set; }
        public ResultUserDto? User { get; set; }
    }
}
