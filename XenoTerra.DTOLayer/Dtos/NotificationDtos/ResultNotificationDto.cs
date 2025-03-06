using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.NotificationDtos
{
    public class ResultNotificationDto
    {
        public Guid NotificationId { get; set; }
        public Guid UserId { get; set; }
        public Guid Message { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
