

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.MessageServices
{
    
    public class MessageServiceDAL : GenericRepositoryDAL<Message, ResultMessageDto, ResultMessageWithRelationsDto, CreateMessageDto, UpdateMessageDto, Guid>, IMessageServiceDAL

    {

        public MessageServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}