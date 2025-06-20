using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own
{
    public class UpdateAppUserOwnDto
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
        public bool? IsVerified { get; set; }
    }
}
