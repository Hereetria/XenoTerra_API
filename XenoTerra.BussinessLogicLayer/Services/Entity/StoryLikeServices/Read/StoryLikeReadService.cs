﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryLikeServices.Read
{
    public class StoryLikeReadService(IReadRepository<StoryLike, Guid> readRepository) : ReadService<StoryLike, Guid>(readRepository), IStoryLikeReadService
    {
    }
}
