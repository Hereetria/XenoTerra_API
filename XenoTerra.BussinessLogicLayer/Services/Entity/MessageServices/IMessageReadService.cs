using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MessageServices
{
    public interface IMessageReadService : IReadService<Message, Guid> { }

}
