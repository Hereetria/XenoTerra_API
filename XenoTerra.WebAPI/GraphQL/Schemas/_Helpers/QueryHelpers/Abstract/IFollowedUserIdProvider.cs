namespace XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract
{
    public interface IFollowedUserIdProvider
    {
        Task<List<Guid>> GetFollowedUserIdsAsync();
    }
}
