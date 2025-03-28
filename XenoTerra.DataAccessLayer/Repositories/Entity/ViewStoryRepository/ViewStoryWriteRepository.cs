using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.ViewStoryRepository
{
    public class ViewStoryWriteRepository(IMapper mapper, AppDbContext context) : WriteRepository<ViewStory, Guid>(mapper, context), IViewStoryWriteRepository
    {
    }
}
