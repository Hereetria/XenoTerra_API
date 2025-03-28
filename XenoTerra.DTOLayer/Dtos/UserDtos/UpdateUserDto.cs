

namespace XenoTerra.DTOLayer.Dtos.UserDtos
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required string FullName { get; set; }
        public required string Bio { get; set; }
        public required string ProfilePicture { get; set; }
        public required string Website { get; set; }
        public DateTime BirthDate { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
        public bool IsVerified { get; set; }
        public DateTime LastActive { get; set; }
    }
}