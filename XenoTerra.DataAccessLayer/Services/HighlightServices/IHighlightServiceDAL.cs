
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.HighlightServices
{
    
    public interface IHighlightServiceDAL : IGenericRepositoryDAL<Highlight, ResultHighlightDto, ResultHighlightByIdDto ,CreateHighlightDto, UpdateHighlightDto, Guid>

    {

    }
}