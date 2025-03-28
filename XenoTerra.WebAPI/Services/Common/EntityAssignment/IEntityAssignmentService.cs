using XenoTerra.DataAccessLayer.Persistence;

namespace XenoTerra.WebAPI.Services.Common.EntityAssignment
{
    public interface IEntityAssignmentService<TEntity, TRelatedEntity, TRelatedKey>
        where TEntity : class
        where TRelatedEntity : class
        where TRelatedKey : notnull
    {
        List<TEntity> AssignRelatedEntities(
            AppDbContext dbContext,
            List<TEntity> entityList,
            IReadOnlyDictionary<TRelatedKey, TRelatedEntity> relatedEntities);
    }
}
