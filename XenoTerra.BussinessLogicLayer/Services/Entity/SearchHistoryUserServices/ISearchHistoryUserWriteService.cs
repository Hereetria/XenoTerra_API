using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryUserServices
{
    public interface ISearchHistoryUserWriteService : IWriteService<SearchHistoryUser, CreateSearchHistoryUserDto, UpdateSearchHistoryUserDto, Guid>
    {
    }

}
