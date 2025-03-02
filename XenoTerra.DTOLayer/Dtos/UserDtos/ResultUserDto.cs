

namespace XenoTerra.DTOLayer.Dtos.UserDtos
{
    public class ResultUserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public string Website { get; set; }
        public DateTime BirthDate { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
        public bool IsVerified { get; set; }
        public DateTime LastActive { get; set; }
    }
}