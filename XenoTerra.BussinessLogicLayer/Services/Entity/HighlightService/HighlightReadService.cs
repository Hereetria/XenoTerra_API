﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.HighlightService
{
    public class HighlightReadService : ReadService<Highlight, ResultHighlightWithRelationsDto, Guid>, IHighlightReadService
    {
        public HighlightReadService(IReadRepository<Highlight, ResultHighlightWithRelationsDto, Guid> repository)
            : base(repository) { }
    }
}
