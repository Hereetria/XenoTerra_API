
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.MessageServices
{
        public interface IMessageServiceBLL : IGenericRepositoryBLL<Message, ResultMessageDto, CreateMessageDto, UpdateMessageDto, Guid>
    {

    }
}