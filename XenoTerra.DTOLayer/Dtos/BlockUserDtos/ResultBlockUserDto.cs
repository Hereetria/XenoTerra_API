using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos
{
    public class ResultBlockUserDto
    {
        public Guid BlockUserId { get; set; }
        public Guid BlockingUserId { get; set; }
        public Guid BlockedUserId { get; set; }
        public DateTime BlockedAt { get; set; }
    }
}
