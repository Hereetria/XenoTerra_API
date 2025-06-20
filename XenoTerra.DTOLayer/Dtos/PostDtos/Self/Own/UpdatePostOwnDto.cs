namespace XenoTerra.DTOLayer.Dtos.PostAdminDtos.Self.Own
{
    public class UpdatePostOwnDto
    {
        public Guid PostId { get; set; }
        public string? Caption { get; set; } = string.Empty;
        public string? Location { get; set; } = string.Empty;
    }
}
