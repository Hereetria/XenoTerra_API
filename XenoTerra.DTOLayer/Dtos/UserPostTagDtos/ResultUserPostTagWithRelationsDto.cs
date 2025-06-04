using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.UserPostTagDtos
{
    public record class ResultUserPostTagWithRelationsDto
    {
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public ResultPostDto Post { get; init; } = new();
        public ResultAppUserPrivateDto User { get; init; } = new();
    }
}
