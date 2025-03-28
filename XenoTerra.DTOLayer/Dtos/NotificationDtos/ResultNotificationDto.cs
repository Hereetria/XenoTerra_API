using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.NotificationDtos
{
    public record ResultNotificationDto(
        Guid NotificationId,
        Guid UserId,
        Guid Message,
        string Image,
        DateTime CreatedAt
    );
}
