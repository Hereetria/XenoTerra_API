using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.SavedPostServices;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.SavedPost
{
    public class SavedPostQuery
    {
        [UseProjection]
        [GraphQLDescription("Get all SavedPosts")]
        public IQueryable<ResultSavedPostDto> GetAllSavedPosts([Service] ISavedPostServiceBLL savedPostServiceBLL)
        {
            return savedPostServiceBLL.GetAllQuerable();
        }

        [UseProjection]
        [GraphQLDescription("Get SavedPost by ID")]
        public IQueryable<ResultSavedPostByIdDto> GetSavedPostById(Guid id, [Service] ISavedPostServiceBLL savedPostServiceBLL)
        {
            var result = savedPostServiceBLL.GetByIdQuerable(id);
            if (result == null)
            {
                throw new Exception($"SavedPost with ID {id} not found");
            }
            return result;
        }
    }
}
