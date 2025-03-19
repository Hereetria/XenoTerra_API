﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.ViewStoryRepository
{
    public class ViewStoryReadRepository : ReadRepository<ViewStory, ResultViewStoryWithRelationsDto, Guid>, IViewStoryReadRepository
    {
        public ViewStoryReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
