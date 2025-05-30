﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryHighlightServices
{
    public class StoryHighlightReadService(IReadRepository<StoryHighlight, Guid> readRepository)
        : ReadService<StoryHighlight, Guid>(readRepository), IStoryHighlightReadService
    {
    }
}
