using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryUserService
{
    public interface ISearchHistoryUserReadService : IReadService<SearchHistoryUser, ResultSearchHistoryUserWithRelationsDto, Guid>
    {
    }
}
