using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.MessageQueryServices
{
    public interface IMessageQueryService : IQueryService<Message, Guid>
    {
    }
}
