using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MessageService
{
    public class MessageWriteService(
            IWriteRepository<Message, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateMessageDto> createValidator,
            IValidator<UpdateMessageDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Message, CreateMessageDto, UpdateMessageDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IMessageWriteService
    {
        protected override Task PreCreateAsync(CreateMessageDto createDto)
        {
            createDto.SentAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
