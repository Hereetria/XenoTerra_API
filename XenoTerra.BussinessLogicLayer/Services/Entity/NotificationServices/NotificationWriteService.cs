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
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NotificationServices
{
    public class NotificationWriteService(
            IWriteRepository<Notification, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateNotificationDto> createValidator,
            IValidator<UpdateNotificationDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Notification, CreateNotificationDto, UpdateNotificationDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            INotificationWriteService
    {
        protected override Task PreCreateAsync(CreateNotificationDto createDto)
        {
            createDto.CreatedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
