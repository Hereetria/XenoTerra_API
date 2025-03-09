using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotChocolate.Execution;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;
using XenoTerra.BussinessLogicLayer.Services.UserServices;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.Schemas.DataLoaders
{
    public class UserDataLoader : BatchDataLoader<Guid, ResultUserDto>
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private static readonly ConcurrentDictionary<Guid, List<string>> _fieldsCache = new();
        private static readonly ConcurrentDictionary<string, LambdaExpression> _expressionCache = new();
        public UserDataLoader(
            IBatchScheduler batchScheduler,
            DataLoaderOptions options,
            IDbContextFactory<AppDbContext> contextFactory) 
                : base(batchScheduler, options)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IReadOnlyDictionary<Guid, ResultUserDto>> LoadAsync(List<Guid> userIds, List<string> selectedFields)
        {
            foreach (var userId in userIds)
            {
                _fieldsCache[userId] = selectedFields;
            }
            return await LoadBatchAsync(userIds, CancellationToken.None);
        }


        protected override async Task<IReadOnlyDictionary<Guid, ResultUserDto>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            var fieldGroups = keys
                .Select(key => new { Key = key, Fields = _fieldsCache.ContainsKey(key) ? _fieldsCache[key] : new List<string>() })
                .GroupBy(x => string.Join(",", x.Fields.OrderBy(f => f)), x => x.Key)
                .ToDictionary(g => g.Key, g => g.ToList());

            await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
            var usersDict = new Dictionary<Guid, ResultUserDto>();

            foreach (var fieldGroup in fieldGroups)
            {
                var selectedFields = fieldGroup.Key.Split(',').ToList();

                if (!selectedFields.Any(f => f.Equals(nameof(ResultUserDto.Id), StringComparison.OrdinalIgnoreCase)))
                {
                    selectedFields.Add(nameof(ResultUserDto.Id));
                }

                var selector = CreateSelectorExpression(selectedFields);

                var groupResults = await context.Users
                    .Where(user => fieldGroup.Value.Contains(user.Id))
                    .Select(selector)
                    .ToDictionaryAsync(user => user.Id, cancellationToken);

                foreach (var kvp in groupResults)
                {
                    usersDict[kvp.Key] = kvp.Value;
                }
            }

            return usersDict;
        }

        private static Expression<Func<User, ResultUserDto>> CreateSelectorExpression(List<string> selectedFields)
        {
            var cacheKey = string.Join(",", selectedFields.OrderBy(f => f));

            if (_expressionCache.TryGetValue(cacheKey, out var cachedExpression))
            {
                return (Expression<Func<User, ResultUserDto>>)cachedExpression;
            }

            var userParameter = Expression.Parameter(typeof(User), "user");
            var dtoParameter = Expression.New(typeof(ResultUserDto));

            var bindings = new List<MemberBinding>();
            var userProperties = typeof(User).GetProperties();
            var dtoProperties = typeof(ResultUserDto).GetProperties();

            foreach (var field in selectedFields)
            {
                var entityProperty = userProperties.FirstOrDefault(p =>
                    string.Equals(p.Name, field, StringComparison.OrdinalIgnoreCase));

                var dtoProperty = dtoProperties.FirstOrDefault(p =>
                    string.Equals(p.Name, field, StringComparison.OrdinalIgnoreCase));

                if (entityProperty != null && dtoProperty != null)
                {
                    var userPropertyExpression = Expression.Property(userParameter, entityProperty);
                    var binding = Expression.Bind(dtoProperty, userPropertyExpression);
                    bindings.Add(binding);
                }
            }

            var body = Expression.MemberInit(dtoParameter, bindings);
            var expression = Expression.Lambda<Func<User, ResultUserDto>>(body, userParameter);

            _expressionCache[cacheKey] = expression; // 🏷 Expression önbelleğe alındı

            return expression;
        }
    }
}
