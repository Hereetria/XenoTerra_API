﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryUserServices
{
    public interface ISearchHistoryUserReadService : IReadService<SearchHistoryUser, Guid>
    {
    }

}
