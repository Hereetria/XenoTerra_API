using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.UserSettingDtos
{
    public record ResultUserSettingDto(
        Guid UserSettingId,
        Guid UserId,
        bool IsPrivate,
        bool ReceiveNotifications,
        bool ShowActivityStatus,
        DateTime LastUpdated
    );
}
