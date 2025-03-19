﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.ViewStoryRepository
{
    public class ViewStoryWriteRepository : WriteRepository<ViewStory, ResultViewStoryDto, Guid>, IViewStoryWriteRepository
    {
        public ViewStoryWriteRepository(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }
}
