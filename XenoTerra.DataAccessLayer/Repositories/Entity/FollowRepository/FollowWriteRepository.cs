﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.FollowRepository
{

    public class FollowWriteRepository : WriteRepository<Follow, ResultFollowDto, Guid>, IFollowWriteRepository
    {
        public FollowWriteRepository(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }

}
