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
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.MessageAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MessageServices.Write.Own
{
    public class MessageOwnWriteService(
            IWriteRepository<Message, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateMessageOwnDto> createValidator,
            IValidator<UpdateMessageOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Message, CreateMessageOwnDto, UpdateMessageOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IMessageOwnWriteService
    {
        protected override Task PreCreateAsync(CreateMessageOwnDto createDto)
        {
            createDto.SentAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
