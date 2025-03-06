
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.MessageServices
{
    
    public interface IMessageServiceDAL : IGenericRepositoryDAL<Message, ResultMessageDto, ResultMessageWithRelationsDto, CreateMessageDto, UpdateMessageDto, Guid>

    {

    }
}