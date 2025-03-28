using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.UserSettingRepository
{
    public interface IUserSettingWriteRepository : IWriteRepository<UserSetting, Guid>
    {
    }
}
