namespace XenoTerra.DTOLayer.Dtos.AppRoleDtos
{
    public record class ResultAppRoleWithRelationsDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}