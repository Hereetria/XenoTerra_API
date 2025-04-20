using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos
{
    public record class ResultBlockUserDto
    {
        public Guid BlockUserId { get; init; }
        public Guid BlockingUserId { get; init; }
        public Guid BlockedUserId { get; init; }
        public DateTime BlockedAt { get; init; }
    }
}
