

namespace XenoTerra.DTOLayer.Dtos.RoleDtos
{
    public record class ResultRoleWithRelationsDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}