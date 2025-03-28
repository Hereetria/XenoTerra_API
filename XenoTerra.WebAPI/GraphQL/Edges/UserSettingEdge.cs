using XenoTerra.DTOLayer.Dtos.UserSettingDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class UserSettingEdge
    {
        public ResultUserSettingWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
