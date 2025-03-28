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
    public record ResultUserPostTagWithRelationsDto(
        Guid PostId,
        Guid UserId
    )
    {
        public ResultPostDto? Post { get; set; }
        public ResultUserDto? User { get; set; }
    }
}
