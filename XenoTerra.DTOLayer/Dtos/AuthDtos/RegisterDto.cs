namespace XenoTerra.DTOLayer.Dtos.AuthDtos
{
    public class RegisterDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        public DateTime LastActive { get; init; } = DateTime.UtcNow;
        public string ProfilePicture { get; init; } = string.Empty;
        public string Bio { get; init; } = string.Empty;
        public string Website { get; init; } = string.Empty;
        public bool IsVerified { get; init; } = false;
        public int FollowersCount { get; init; } = 0;
        public int FollowingCount { get; init; } = 0;
    }
}