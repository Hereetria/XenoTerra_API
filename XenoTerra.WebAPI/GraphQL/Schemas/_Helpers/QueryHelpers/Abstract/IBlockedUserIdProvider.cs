namespace XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract
{
    public interface IBlockedUserIdProvider
    {
        Task<List<Guid>> GetBlockedUserIdsAsync(Guid currentUserId);
    }
}
