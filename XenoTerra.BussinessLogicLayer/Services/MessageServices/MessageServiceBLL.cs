
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.BussinessLogicLayer.Services.MessageServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.MessageServices
{
     public class MessageServiceBLL : GenericRepositoryBLL<Message, ResultMessageDto, ResultMessageByIdDto, CreateMessageDto, UpdateMessageDto, Guid>, IMessageServiceBLL
    {
        public MessageServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}