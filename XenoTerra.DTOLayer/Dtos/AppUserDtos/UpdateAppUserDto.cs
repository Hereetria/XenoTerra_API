namespace XenoTerra.DTOLayer.Dtos.AppUserDtos
{
    public class UpdateAppUserDto
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? FullName { get; set; } = string.Empty;
        public string? Bio { get; set; } = string.Empty;
        public string? ProfilePicture { get; set; } = string.Empty;
        public string? Website { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public int? FollowersCount { get; set; }
        public int? FollowingCount { get; set; }
        public bool? IsVerified { get; set; }
        public DateTime? LastActive { get; set; }
    }
}