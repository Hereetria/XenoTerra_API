namespace XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract
{
    public interface IPublicUserIdProvider
    {
        Task<List<Guid>> GetPublicUserIdsAsync();
    }
}
