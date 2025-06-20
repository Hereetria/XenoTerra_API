using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.RecentChatsAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsServices.Write.Admin
{
    public interface IRecentChatsAdminWriteService : IWriteService<RecentChats, CreateRecentChatsAdminDto, UpdateRecentChatsAdminDto, Guid> { }
}
