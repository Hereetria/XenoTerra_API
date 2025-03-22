using XenoTerra.DataAccessLayer.Contexts;

namespace XenoTerra.WebAPI.Services.Common.EntityAssignment
{
    public interface IEntityAssignmentService<TEntity, TDtoResult, TRelatedDtoResult, TRelatedKey>
    where TEntity : class
        where TDtoResult : class
        where TRelatedDtoResult : class
        where TRelatedKey : notnull
    {
        List<TDtoResult> AssignRelatedEntities(
            AppDbContext dbContext,
            List<TDtoResult> dtoList,
            IReadOnlyDictionary<TRelatedKey, TRelatedDtoResult> relatedEntities);
    }
}
