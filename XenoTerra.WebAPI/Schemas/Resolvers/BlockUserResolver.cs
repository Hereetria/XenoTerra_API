using GreenDonut;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<ResultBlockUserWithRelationsDto> ModifyQuery(
            IQueryable<BlockUser> query,
            IResolverContext context)
        {
            var dbContext = context.Service<AppDbContext>();
            var selectedNestedFields = GraphQLFieldProvider.GetNestedSelectedFields(context, "blockingUser");
            var selector = SimpleProjectonExpressionProvider.CreateSelectorExpression<User>(selectedNestedFields);

            var innerQuery = dbContext.Set<User>().Select(selector);

            var joinedQuery = query.Join<BlockUser, User, Guid, ResultBlockUserWithRelationsDto>(
                innerQuery,
                blockUser => blockUser.BlockingUserId,
                user => user.Id,
                (blockUser, blockingUser) => new ResultBlockUserWithRelationsDto
                {
                    BlockUserId = blockUser.BlockUserId,
                    BlockingUserId = blockUser.BlockingUserId,
                    BlockedUserId = blockUser.BlockedUserId,
                    BlockedAt = blockUser.BlockedAt,

                    BlockedUser = blockUser.BlockedUser != null ? MapToDto<User, ResultUserDto>(blockUser.BlockedUser) : null,
                    BlockingUser = blockingUser != null ? MapToDto<User, ResultUserDto>(blockingUser) : null
                });

            return joinedQuery;
        }

        // User -> ResultUserDto dönüşüm metodu


        public IQueryable<TResultDto> ApplyJoinWithProjection<TEntity, TRelatedEntity, TResultDto, TProjectionDto, TKey>(
            IQueryable<TEntity> query, // DTO yerine Entity kullanıyoruz
            IResolverContext context,
            string relatedFieldName)
            where TEntity : class // BlockUser
            where TRelatedEntity : class, new() // User
            where TResultDto : class, new() // ResultBlockUserWithRelationsDto
            where TProjectionDto : class, new() // ResultUserDto
        {
            var dbContext = context.Service<AppDbContext>();
            var selectedNestedFields = GraphQLFieldProvider.GetNestedSelectedFields(context, relatedFieldName);
            var selector = SimpleProjectonExpressionProvider.CreateSelectorExpression<TRelatedEntity>(selectedNestedFields);
            var innerQuery = dbContext.Set<TRelatedEntity>();


            var joinForeignKeySelector = CreateJoinForeignKeySelector<TEntity, TKey>(relatedFieldName, dbContext);
            var joinRelatedKeySelector = CreateJoinRelatedKeySelector<TRelatedEntity, TKey>(dbContext);
            var joinResultSelector = CreateJoinResultSelector<TEntity, TRelatedEntity, TResultDto, TProjectionDto>(relatedFieldName);

            // Entity üzerinden Join işlemi
            var joinedQuery = query.Join(
                innerQuery,
                joinForeignKeySelector,
                joinRelatedKeySelector,
                joinResultSelector
            );
            return joinedQuery;
        }




        private Expression<Func<TEntity, TRelatedEntity, TResultDto>> CreateJoinResultSelector<TEntity, TRelatedEntity, TResultDto, TProjectionDto>(
            string relatedFieldName)
            where TEntity : class // BlockUser
            where TRelatedEntity : class // User
            where TResultDto : class, new() // ResultBlockUserWithRelationsDto
            where TProjectionDto : class, new() // ResultUserDto
        {
            var entityParameter = Expression.Parameter(typeof(TEntity), "entity");
            var relatedParameter = Expression.Parameter(typeof(TRelatedEntity), "relatedEntity");

            var bindings = new List<MemberBinding>();

            var resultDtoProperties = typeof(TResultDto).GetProperties();
            var entityProperties = typeof(TEntity).GetProperties()
                .ToDictionary(p => p.Name.ToLowerInvariant(), p => p);

            var relatedEntityProperty = resultDtoProperties
                .FirstOrDefault(p => p.Name.ToLowerInvariant() == relatedFieldName.ToLowerInvariant());

            foreach (var resultDtoProperty in resultDtoProperties)
            {
                bool isPrimitiveType = resultDtoProperty.PropertyType.IsPrimitive
                       || resultDtoProperty.PropertyType == typeof(string)
                       || resultDtoProperty.PropertyType == typeof(Guid)
                       || resultDtoProperty.PropertyType == typeof(DateTime)
                       || resultDtoProperty.PropertyType == typeof(decimal);

                if (!isPrimitiveType)
                {
                    var projectionExpression = CreateDtoProjectionExpression<TRelatedEntity, TProjectionDto>(relatedParameter);

                    if (relatedEntityProperty != null &&
                        resultDtoProperty.Name.ToLowerInvariant() == relatedEntityProperty.Name.ToLowerInvariant())
                    {
                        // ✅ `BlockingUser` için Expression
                        var relatedEntityNullCheck = Expression.NotEqual(relatedParameter, Expression.Constant(null, typeof(TRelatedEntity)));

                        var blockingUserProjectionExpression = Expression.Condition(
                            relatedEntityNullCheck,
                            projectionExpression,
                            Expression.Constant(null, resultDtoProperty.PropertyType)
                        );

                        bindings.Add(Expression.Bind(resultDtoProperty, blockingUserProjectionExpression));
                    }
                    else
                    {
                        // ✅ `BlockedUser` için Expression
                        if (entityProperties.TryGetValue("blockeduser", out var blockedUserProperty)
                            && blockedUserProperty.PropertyType == typeof(TRelatedEntity))
                        {
                            var blockedUserAccess = Expression.Property(entityParameter, blockedUserProperty);
                            var blockedUserProjectionExpression = CreateDtoProjectionExpression<TRelatedEntity, TProjectionDto>(blockedUserAccess);

                            var blockedUserNullCheck = Expression.NotEqual(blockedUserAccess, Expression.Constant(null, typeof(TRelatedEntity)));

                            var blockedUserFinalExpression = Expression.Condition(
                                blockedUserNullCheck,
                                blockedUserProjectionExpression,
                                Expression.Constant(null, resultDtoProperty.PropertyType)
                            );

                            bindings.Add(Expression.Bind(resultDtoProperty, blockedUserFinalExpression));
                        }
                    }
                }
                else if (entityProperties.TryGetValue(resultDtoProperty.Name.ToLowerInvariant(), out var entityProperty))
                {
                    var entityPropertyAccess = Expression.Property(entityParameter, entityProperty);
                    bindings.Add(Expression.Bind(resultDtoProperty, entityPropertyAccess));
                }
            }

            var newDtoExpression = Expression.New(typeof(TResultDto));
            var memberInitExpression = Expression.MemberInit(newDtoExpression, bindings);
            return Expression.Lambda<Func<TEntity, TRelatedEntity, TResultDto>>(memberInitExpression, entityParameter, relatedParameter);
        }




        private static Expression CreateDtoProjectionExpression<TSource, TDestination>(Expression sourceExpression)
            where TSource : class
            where TDestination : class, new()
        {
            var dtoBindings = new List<MemberBinding>();

            foreach (var dtoProperty in typeof(TDestination).GetProperties())
            {
                var sourceProperty = typeof(TSource).GetProperty(dtoProperty.Name);
                if (sourceProperty != null)
                {
                    var sourcePropertyAccess = Expression.Property(sourceExpression, sourceProperty);
                    var dtoBinding = Expression.Bind(dtoProperty, sourcePropertyAccess);
                    dtoBindings.Add(dtoBinding);
                }
            }

            var newDtoExpression = Expression.New(typeof(TDestination));
            return Expression.MemberInit(newDtoExpression, dtoBindings);
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

        private Expression<Func<TEntity, TKey>> CreateJoinForeignKeySelector<TEntity, TKey>(
            string relatedFieldName,
            DbContext dbContext)
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

        public static TResult MapToDto<TEntity, TResult>(TEntity entity)
            where TEntity : class
            where TResult : class, new()
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");

            var result = new TResult();
            var entityProperties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var resultProperties = typeof(TResult).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var resultProperty in resultProperties)
            {
                var entityProperty = entityProperties.FirstOrDefault(p => p.Name == resultProperty.Name &&
                                                                          p.PropertyType == resultProperty.PropertyType);

                if (entityProperty is null)
                    continue;

                try
                {
                     var value = entityProperty.GetValue(entity);
                    resultProperty.SetValue(result, value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Property mapping failed: {resultProperty.Name} - {ex.Message}");
                }
            }
            return result;
        }




        public async Task PopulateBlockUsersAsync(
            [Parent] ResultBlockUserWithRelationsDto blockUserDto,
            UserDataLoader userDataLoader,
            IResolverContext context)
        {
            var selectedFields = GetSelectedFields(context);

            var userIds = new List<Guid>();
            if (blockUserDto.BlockingUserId != Guid.Empty)
                userIds.Add(blockUserDto.BlockingUserId);
            if (blockUserDto.BlockedUserId != Guid.Empty)
                userIds.Add(blockUserDto.BlockedUserId);

            if (!userIds.Any())
                return;

            var usersDict = await userDataLoader.LoadAsync(userIds, selectedFields);

            if (usersDict.TryGetValue(blockUserDto.BlockingUserId, out var blockingUser))
                blockUserDto.BlockingUser = blockingUser;

            if (usersDict.TryGetValue(blockUserDto.BlockedUserId, out var blockedUser))
                blockUserDto.BlockedUser = blockedUser;
        }

        private List<string> GetSelectedFields(IResolverContext context)
        {
            return context.Selection.SyntaxNode.SelectionSet?.Selections
                .OfType<FieldNode>()
                .Select(s => s.Name.Value)
                .ToList() ?? new List<string>();
        }
    }

}

