using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.UserPostTagDtos
{
    public record class ResultUserPostTagDto
    {
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
    }
}
