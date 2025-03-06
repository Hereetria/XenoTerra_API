using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotChocolate.Execution;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq.Expressions;
using System.Reflection;
using XenoTerra.BussinessLogicLayer.Services.UserServices;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.Schemas.DataLoaders
{
    public class UserDataLoader : BatchDataLoader<Guid, ResultUserDto>
    {
        private readonly IDbContextFactory<Context> _contextFactory;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly Context _context;
        private readonly Dictionary<Guid, List<string>> _selectedFieldsCache = new();
        public UserDataLoader(
            IBatchScheduler batchScheduler,
            DataLoaderOptions options,
            IDbContextFactory<Context> contextFactory,
            IServiceProvider serviceProvider
,
            IMapper mapper
,
            Context context) : base(batchScheduler, options)
        {
            _contextFactory = contextFactory;
            _serviceProvider = serviceProvider;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ResultUserDto?> LoadAsync(Guid userId, List<string> selectedFields)
        {
            return await LoadAsync(userId, selectedFields);
        }

        protected async override Task<IReadOnlyDictionary<Guid, ResultUserDto>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            if (!keys.Any())
                return new Dictionary<(Guid, List<string>), ResultUserDto>();

            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<Context>();

            var userIds = keys.Select(k => k.Item1).Distinct().ToList();
            var selectedFields = keys.First().Item2;

            var parameter = Expression.Parameter(typeof(User), "user");
            var bindings = selectedFields
                .Select(field => typeof(User).GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance))
                .Where(property => property != null)
                .Select(property => Expression.Bind(typeof(ResultUserDto).GetProperty(property!.Name)!, Expression.Property(parameter, property!)))
                .ToList();

            var body = Expression.MemberInit(Expression.New(typeof(ResultUserDto)), bindings);
            var selector = Expression.Lambda<Func<User, ResultUserDto>>(body, parameter);

            var users = await dbContext.Users
                .Where(user => userIds.Contains(user.Id))
                .Select(selector)
                .ToListAsync(cancellationToken);

            return users.ToDictionary(user => (user.Id, selectedFields));
        }
    }
}
