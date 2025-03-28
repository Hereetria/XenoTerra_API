﻿using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NotificationService
{
    public class NotificationWriteService(
            IWriteRepository<Notification, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateNotificationDto> createValidator,
            IValidator<UpdateNotificationDto> updateValidator
        )
            : WriteService<Notification, CreateNotificationDto, UpdateNotificationDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator
            ),
            INotificationWriteService
    {
    }
}
