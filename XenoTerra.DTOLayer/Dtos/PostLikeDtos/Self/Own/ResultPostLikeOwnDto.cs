namespace XenoTerra.DTOLayer.Dtos.PostLikeAdminDtos.Self.Own
{
    public class ResultPostLikeOwnDto
    {
        public Guid PostLikeId { get; init; }
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }
    }
}