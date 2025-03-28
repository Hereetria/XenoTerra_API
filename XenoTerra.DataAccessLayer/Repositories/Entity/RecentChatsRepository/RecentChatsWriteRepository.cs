using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.RecentChatsRepository
{
    public class RecentChatsWriteRepository(IMapper mapper, AppDbContext context) : WriteRepository<RecentChats, Guid>(mapper, context), IRecentChatsWriteRepository
    {
    }
}
