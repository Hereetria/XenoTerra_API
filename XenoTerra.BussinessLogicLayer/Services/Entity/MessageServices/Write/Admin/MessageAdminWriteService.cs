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
using XenoTerra.DTOLayer.Dtos.MessageDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MessageServices.Write.Admin
{
    public class MessageAdminWriteService(
            IWriteRepository<Message, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateMessageAdminDto> createValidator,
            IValidator<UpdateMessageAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Message, CreateMessageAdminDto, UpdateMessageAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IMessageAdminWriteService
    {
        protected override Task PreCreateAsync(CreateMessageAdminDto createDto)
        {
            createDto.SentAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
