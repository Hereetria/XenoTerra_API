using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsServices.Write.Own
{
    public interface IRecentChatsOwnWriteService : IWriteService<RecentChats, CreateRecentChatsOwnDto, UpdateRecentChatsOwnDto, Guid> { }
}
