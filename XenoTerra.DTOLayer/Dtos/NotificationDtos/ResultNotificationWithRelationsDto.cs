

using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.DTOLayer.Dtos.NotificationDtos
{
    public record class ResultNotificationWithRelationsDto
    {
        public Guid NotificationId { get; init; }
        public Guid UserId { get; init; }
        public Guid Message { get; init; }
        public string Image { get; init; } = string.Empty;
        public DateTime CreatedAt { get; init; }
        public ResultAppUserPrivateDto User { get; init; } = new();
    }
}