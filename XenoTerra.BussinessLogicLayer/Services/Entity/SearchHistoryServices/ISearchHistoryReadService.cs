﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryServices
{
    public interface ISearchHistoryReadService : IReadService<SearchHistory, Guid> { }

}
