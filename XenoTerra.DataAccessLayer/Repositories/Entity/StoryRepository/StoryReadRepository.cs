﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.StoryRepository
{
    public class StoryReadRepository : ReadRepository<Story, ResultStoryWithRelationsDto, Guid>, IStoryReadRepository
    {
        public StoryReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
