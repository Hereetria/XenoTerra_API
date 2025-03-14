using GreenDonut;
using HotChocolate.Data.Projections.Context;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Resolvers
{
    public class BlockUserResolver
    {

        public IQueryable<TEntity> ModifyQuery<TEntity>(
            IQueryable<TEntity> query,
            IResolverContext context)
        {
            var relatedFields = GraphQLFieldProvider.GetRelationalFields(context);

            foreach (var relatedField in relatedFields)
            {
                Type relatedEntityType = typeof(TEntity)
                    .GetProperties()
                    .FirstOrDefault(p => string.Equals(p.Name, relatedField, StringComparison.OrdinalIgnoreCase))
                    ?.PropertyType
                    ?? throw new InvalidOperationException($"RelatedEntityType for '{relatedField}' cannot be determined.");

                var resolverInstance = Activator.CreateInstance(typeof(BlockUserResolver))
                    ?? throw new InvalidOperationException("Failed to create an instance of BlockUserResolver.");

                MethodInfo applyJoinMethod = typeof(BlockUserResolver)
                    .GetMethod(nameof(ApplyJoin), BindingFlags.Public | BindingFlags.Instance)
                    ?.MakeGenericMethod(typeof(TEntity), relatedEntityType)
                    ?? throw new InvalidOperationException("ApplyJoin method not found.");

                query = applyJoinMethod.Invoke(resolverInstance, new object[] { query, context, relatedField })
                    is IQueryable<TEntity> updatedQuery
                    ? updatedQuery
                    : throw new InvalidOperationException($"ApplyJoin method returned an invalid type. Expected IQueryable<{typeof(TEntity).Name}>.");
            }

            return query;
        }



        public IQueryable<TEntity> ApplyJoin<TEntity, TRelatedEntity>(
            IQueryable<TEntity> query,
            IResolverContext context,
            string relatedField)
            where TEntity : class, new()
            where TRelatedEntity : class, new()
        {
            var dbContext = context.Service<AppDbContext>();
            var nestedSelectedFields = GraphQLFieldProvider.GetNestedSelectedFields(context, relatedField);
            var selector = SimpleProjectonExpressionProvider.CreateSelectorExpression<TRelatedEntity>(nestedSelectedFields);


            var foreignKeySelector = CreateJoinForeignKeySelector<TEntity, Guid>(dbContext, relatedField);
            var relatedKeySelector = CreateJoinRelatedKeySelector<TRelatedEntity, Guid>(dbContext);
            var resultSelector = CreateJoinResultSelector<TEntity, TRelatedEntity>(context, relatedField);
            var relatedDbSet = GetRelatedDbSet<TRelatedEntity>(dbContext)
                ?? throw new InvalidOperationException($"DbSet for type {typeof(TRelatedEntity).Name} not found in DbContext.");


            return query.Join(
                relatedDbSet.Select(selector),
                foreignKeySelector,
                relatedKeySelector,
                resultSelector);
        }



        public Expression<Func<TEntity, TRelatedEntity, TEntity>> CreateJoinResultSelector<TEntity, TRelatedEntity>(
            IResolverContext context,
            string relatedField)
            where TEntity : class, new()
            where TRelatedEntity : class, new()
        {
            var dbContext = context.Service<AppDbContext>();
            var selectedFields = GraphQLFieldProvider.GetSelectedFields(context);
            var nestedSelectedFields = GraphQLFieldProvider.GetNestedSelectedFields(context, relatedField);
            var entityType = dbContext.Model.FindEntityType(typeof(TEntity))
                ?? throw new InvalidOperationException($"Entity '{typeof(TEntity).Name}' not found in DbContext.");

            var entityProperties = entityType.GetProperties()
                                             .Select(p => p.Name)
                                             .ToList();

            var entityParam = Expression.Parameter(typeof(TEntity), "entity");
            var relatedParam = Expression.Parameter(typeof(TRelatedEntity), "relatedEntity");

            var bindings = new List<MemberBinding>();

            foreach (var field in selectedFields)
            {
                var property = typeof(TEntity)
    .GetProperties()
    .FirstOrDefault(p => string.Equals(p.Name, field, StringComparison.InvariantCultureIgnoreCase))
    ?? throw new NullReferenceException("cannot be null");
                if (!GraphQLFieldProvider.IsNonRelationalField(context, field))
                {

                    var relatedBindings = nestedSelectedFields
                               .Select(nestedField => new
                               {
                                   Field = nestedField,
                                   PropertyInfo = typeof(TRelatedEntity).GetProperties()
                                       .FirstOrDefault(p => string.Equals(p.Name, nestedField, StringComparison.InvariantCultureIgnoreCase))
                               })
                               .Where(x => x.PropertyInfo != null)
                               .Select(x => Expression.Bind(x.PropertyInfo!, Expression.Property(relatedParam, x.PropertyInfo!)))
                               .ToList();

                    if (relatedBindings.Any())
                    {
                        var newRelatedEntity = Expression.New(typeof(TRelatedEntity));
                        var relatedMemberInit = Expression.MemberInit(newRelatedEntity, relatedBindings);
                        bindings.Add(Expression.Bind(property, relatedMemberInit));
                    }
                }
 
                else
                {
                    bindings.Add(Expression.Bind(property, Expression.Property(entityParam, property)));
                }
            }
            var newEntity = Expression.New(typeof(TEntity));
            var memberInit = Expression.MemberInit(newEntity, bindings);

            return Expression.Lambda<Func<TEntity, TRelatedEntity, TEntity>>(memberInit, entityParam, relatedParam);

        }

        private static IQueryable<TRelatedEntity>? GetRelatedDbSet<TRelatedEntity>(AppDbContext dbContext)
where TRelatedEntity : class
        {
            var dbSetProperty = dbContext.GetType().GetProperties()
                .FirstOrDefault(p => p.PropertyType.IsGenericType &&
                                     p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                                     p.PropertyType.GenericTypeArguments.Contains(typeof(TRelatedEntity)));

            return dbSetProperty?.GetValue(dbContext) as IQueryable<TRelatedEntity>;
        }



        private Expression<Func<TEntity, TKey>> CreateJoinForeignKeySelector<TEntity, TKey>(
            DbContext dbContext,
            string relatedFieldName)
            where TEntity : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TEntity))
                ?? throw new InvalidOperationException($"Entity metadata for {typeof(TEntity).Name} not found.");

            var navigation = entityType.GetNavigations()
                .FirstOrDefault(n => string.Equals(n.Name, relatedFieldName, StringComparison.OrdinalIgnoreCase))
                ?? throw new InvalidOperationException($"Navigation property '{relatedFieldName}' not found in {typeof(TEntity).Name}.");

            var foreignKey = navigation.ForeignKey.Properties.FirstOrDefault()
                ?? throw new InvalidOperationException($"Foreign key for navigation '{relatedFieldName}' not found.");

            var entityParameter = Expression.Parameter(typeof(TEntity), "entity");
            var propertyAccess = Expression.Property(entityParameter, foreignKey.Name);

            return Expression.Lambda<Func<TEntity, TKey>>(propertyAccess, entityParameter);
        }

        private static Expression<Func<TRelatedEntity, TKey>> CreateJoinRelatedKeySelector<TRelatedEntity, TKey>(
            DbContext dbContext)
            where TRelatedEntity : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TRelatedEntity))
                ?? throw new InvalidOperationException($"Entity metadata for {typeof(TRelatedEntity).Name} not found.");

            var primaryKeyProperty = entityType.FindPrimaryKey()?.Properties.FirstOrDefault()
                ?? throw new InvalidOperationException($"Primary key for {typeof(TRelatedEntity).Name} not found.");

            var entityParameter = Expression.Parameter(typeof(TRelatedEntity), "entity");
            var propertyAccess = Expression.Property(entityParameter, primaryKeyProperty.Name);

            return Expression.Lambda<Func<TRelatedEntity, TKey>>(propertyAccess, entityParameter);
        }
    }

}

