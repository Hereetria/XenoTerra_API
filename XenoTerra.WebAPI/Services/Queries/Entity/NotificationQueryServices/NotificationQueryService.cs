using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.NotificationQueryServices
{
    public class NotificationQueryService : QueryService<Notification, Guid>, INotificationQueryService
    {
        public NotificationQueryService(IReadService<Notification, Guid> readService, IMapper mapper)
            : base(readService, mapper) { }
    }
}
