using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.NotificationRepositories
{
    public interface INotificationReadRepository : IReadRepository<Notification, Guid>
    {
    }
}
