﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryService
{
    public interface IViewStoryWriteService : IWriteService<ViewStory, CreateViewStoryDto, UpdateViewStoryDto, Guid> { }

}
