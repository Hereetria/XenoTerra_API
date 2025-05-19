

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.NotificationDtos
{
    public record class ResultNotificationWithRelationsDto
    {
        public Guid NotificationId { get; init; }
        public Guid UserId { get; init; }
        public Guid Message { get; init; }
        public string Image { get; init; } = string.Empty;
        public DateTime CreatedAt { get; init; }
        public ResultUserPrivateDto User { get; init; } = new();
    }
}