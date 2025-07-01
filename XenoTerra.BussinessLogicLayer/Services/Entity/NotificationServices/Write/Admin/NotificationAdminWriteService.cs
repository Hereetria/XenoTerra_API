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
using XenoTerra.DTOLayer.Dtos.NotificationDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NotificationServices.Write.Admin
{
    public class NotificationAdminWriteService(
            IWriteRepository<Notification, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateNotificationAdminDto> createValidator,
            IValidator<UpdateNotificationAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Notification, CreateNotificationAdminDto, UpdateNotificationAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            INotificationAdminWriteService
    {
        protected override Task PreCreateAsync(CreateNotificationAdminDto createDto)
        {
            createDto.CreatedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
