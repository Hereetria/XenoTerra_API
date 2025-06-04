using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.AppUserDtos
{
    public class ResultAppUserWithRelationsPublicDto
    {
        public Guid Id { get; init; }
        public string UserName { get; init; } = string.Empty;
        public string FullName { get; init; } = string.Empty;
        public string ProfilePicture { get; init; } = string.Empty;
        public string Bio { get; init; } = string.Empty;
        public string Website { get; init; } = string.Empty;
        public bool IsVerified { get; init; }
        public int FollowersCount { get; init; }
        public int FollowingCount { get; init; }
        public DateTime? LastActive { get; init; }
    }
}
