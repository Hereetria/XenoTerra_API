namespace XenoTerra.DTOLayer.Dtos.RecentChatsAdminDtos.Self.Own
{
    public class ResultRecentChatsOwnDto
    {
        public Guid RecentChatsId { get; init; }
        public string LastMessage { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime LastMessageAt { get; init; }
    }
}