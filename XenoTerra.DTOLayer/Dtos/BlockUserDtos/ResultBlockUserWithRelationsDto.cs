

using HotChocolate;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos
{
    public class ResultBlockUserWithRelationsDto
    {
        public Guid BlockUserId { get; set; }
        public Guid BlockingUserId { get; set; }
        public Guid BlockedUserId { get; set; }
        public DateTime BlockedAt { get; set; }

        [GraphQLIgnore]
        public ResultUserDto? BlockingUser { get; set; }

        [GraphQLIgnore]
        public ResultUserDto? BlockedUser { get; set; }
    }
}