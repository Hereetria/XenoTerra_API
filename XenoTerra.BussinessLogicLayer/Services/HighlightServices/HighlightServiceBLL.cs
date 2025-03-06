
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.BussinessLogicLayer.Services.HighlightServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.HighlightServices
{
     public class HighlightServiceBLL : GenericRepositoryBLL<Highlight, ResultHighlightDto, ResultHighlightWithRelationsDto, CreateHighlightDto, UpdateHighlightDto, Guid>, IHighlightServiceBLL
    {
        public HighlightServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}