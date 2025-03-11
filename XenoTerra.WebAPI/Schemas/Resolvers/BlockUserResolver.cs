using GreenDonut;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
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

                    BlockedUser = blockUser.BlockedUser != null ? MapUserToDto(blockUser.BlockedUser) : null,
                    BlockingUser = blockingUser != null ? MapUserToDto(blockingUser) : null
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
            var innerQuery = dbContext.Set<TRelatedEntity>().Select(selector);


            var joinForeignKeySelector = CreateJoinForeignKeySelector<TEntity, TKey>(relatedFieldName, dbContext);
            var joinRelatedKeySelector = CreateJoinRelatedKeySelector<TRelatedEntity, TKey>(dbContext);
            var joinResultSelector = CreateJoinResultSelector<TEntity, TRelatedEntity, TResultDto, TProjectionDto>(relatedFieldName);

            // Entity üzerinden Join işlemi
            var joinedQuery = query.Join<TEntity, TRelatedEntity, TKey, TResultDto>(
                innerQuery, // ProjectionDto seçiliyor
                joinForeignKeySelector.Compile(), // blockUser => blockUser.BlockingUserId
                joinRelatedKeySelector.Compile(), // user => user.Id
                joinResultSelector.Compile() // DTO dönüşümü burada yapılır
            );



            return joinedQuery.AsQueryable();
        }



        private static TKey GetPrimaryKeyFromProjection<TProjectionDto, TKey>(TProjectionDto projectionEntity)
    where TProjectionDto : class
        {
            var keyProperty = typeof(TProjectionDto).GetProperties()
                .FirstOrDefault(p => p.Name.Equals("Id", StringComparison.OrdinalIgnoreCase));

            if (keyProperty == null)
                throw new InvalidOperationException($"Primary key for {typeof(TProjectionDto).Name} not found.");

            return (TKey)keyProperty.GetValue(projectionEntity);
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


        private Expression<Func<TEntity, TRelatedEntity, TResultDto>> CreateJoinResultSelector<TEntity, TRelatedEntity, TResultDto, TProjectionDto>(
            string relatedFieldName)
            where TEntity : class
            where TRelatedEntity : class
            where TResultDto : class, new()
            where TProjectionDto : class, new()
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
                if (relatedEntityProperty != null && resultDtoProperty.Name.ToLowerInvariant() == relatedEntityProperty.Name.ToLowerInvariant())
                {
                    // `MapUserToDto` metodunu reflection ile bul
                    var mapMethod = typeof(BlockUserResolver).GetMethod(nameof(MapUserToDto),
                        System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);

                    if (mapMethod == null)
                    {
                        throw new InvalidOperationException("MapUserToDto method not found. Ensure it is static and public.");
                    }

                    // `relatedParameter`'ı `User` türüne dönüştür
                    var userCast = Expression.Convert(relatedParameter, typeof(User));

                    // `MapUserToDto(User)` metodunu çağır
                    var mapCall = Expression.Call(mapMethod, userCast);

                    // Dönüşümü `ResultUserDto`'ya uygun hale getir
                    var convertedCall = Expression.Convert(mapCall, typeof(ResultUserDto));

                    // DTO'ya bağla
                    bindings.Add(Expression.Bind(resultDtoProperty, convertedCall));
                }
                else if (entityProperties.TryGetValue(resultDtoProperty.Name.ToLower(), out var entityProperty))
                {
                    var entityPropertyAccess = Expression.Property(entityParameter, entityProperty);
                    bindings.Add(Expression.Bind(resultDtoProperty, entityPropertyAccess));
                }
            }

            var newDtoExpression = Expression.New(typeof(TResultDto));
            var memberInitExpression = Expression.MemberInit(newDtoExpression, bindings);
            return Expression.Lambda<Func<TEntity, TRelatedEntity, TResultDto>>(memberInitExpression, entityParameter, relatedParameter);
        }


        public static ResultUserDto? MapUserToDto(User user)
        {
            if (user == null) return null;

            return new ResultUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
                // Eğer ResultUserDto içinde daha fazla alan varsa buraya ekleyin.
            };
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

