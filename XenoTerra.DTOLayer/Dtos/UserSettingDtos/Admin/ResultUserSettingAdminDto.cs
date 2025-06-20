using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Admin
{
    public class ResultUserSettingAdminDto
    {
        public Guid UserSettingId { get; init; }
        public Guid UserId { get; init; }
        public bool IsPrivate { get; init; }
        public bool ReceiveNotifications { get; init; }
        public bool ShowActivityStatus { get; init; }
        public DateTime LastUpdated { get; init; }
    }
}
