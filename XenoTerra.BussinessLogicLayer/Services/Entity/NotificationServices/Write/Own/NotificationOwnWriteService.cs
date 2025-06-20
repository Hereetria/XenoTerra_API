using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
using XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NotificationServices.Write.Own
{
    public class NotificationOwnWriteService(
            IWriteRepository<Notification, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateNotificationOwnDto> createValidator,
            IValidator<UpdateNotificationOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Notification, CreateNotificationOwnDto, UpdateNotificationOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            INotificationOwnWriteService
    {
        protected override Task PreCreateAsync(CreateNotificationOwnDto createDto)
        {
            createDto.CreatedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
