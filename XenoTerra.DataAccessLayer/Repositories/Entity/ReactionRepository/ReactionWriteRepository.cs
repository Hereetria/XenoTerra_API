﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.ReactionRepository
{
    public class ReactionWriteRepository : WriteRepository<Reaction, ResultReactionDto, Guid>, IReactionWriteRepository
    {
        public ReactionWriteRepository(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }
}
