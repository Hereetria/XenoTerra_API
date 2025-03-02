using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.FollowServices;
using XenoTerra.DTOLayer.Dtos.FollowDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.Follow
{
    public class FollowQuery
    {
        [UseProjection]
        [GraphQLDescription("Get all Follows")]
        public IQueryable<ResultFollowDto> GetAllFollows([Service] IFollowServiceBLL followServiceBLL)
        {
            return followServiceBLL.GetAllQuerable();
        }

        [UseProjection]
        [GraphQLDescription("Get Follow by ID")]
        public IQueryable<ResultFollowByIdDto> GetFollowById(Guid id, [Service] IFollowServiceBLL followServiceBLL)
        {
            var result = followServiceBLL.GetByIdQuerable(id);
            if (result == null)
            {
                throw new Exception($"Follow with ID {id} not found");
            }
            return result;
        }
    }
}
