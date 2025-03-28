﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.NotificationRepository
{
    public interface INotificationWriteRepository : IWriteRepository<Notification, Guid>
    {
    }
}
