
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.HighlightServices
{
        public interface IHighlightServiceBLL : IGenericRepositoryBLL<Highlight, ResultHighlightDto, ResultHighlightWithRelationsDto, CreateHighlightDto, UpdateHighlightDto, Guid>
    {

    }
}