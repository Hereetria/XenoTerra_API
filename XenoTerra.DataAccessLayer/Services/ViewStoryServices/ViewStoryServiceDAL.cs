

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.ViewStoryServices
{
    
    public class ViewStoryServiceDAL : GenericRepositoryDAL<ViewStory, ResultViewStoryDto, ResultViewStoryByIdDto, CreateViewStoryDto, UpdateViewStoryDto, Guid>, IViewStoryServiceDAL

    {

        public ViewStoryServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}