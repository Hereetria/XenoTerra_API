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
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.Schemas.DataLoaders
{
    public class UserDataLoader : BatchDataLoader<Guid, ResultUserDto>
    {
        private readonly IUserServiceBLL _userServiceBLL;
        private readonly IDbContextFactory<Context> _contextFactory;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly Context _context;
        private readonly ConcurrentDictionary<Guid, List<string>> _fieldsCache = new(); private readonly Dictionary<Guid, List<string>> _selectedFieldsCache = new();
        public UserDataLoader(
            IBatchScheduler batchScheduler,
            DataLoaderOptions options,
            IDbContextFactory<Context> contextFactory,
            IServiceProvider serviceProvider
,
            IMapper mapper
,
            Context context,
            IUserServiceBLL userServiceBLL) : base(batchScheduler, options)
        {
            _contextFactory = contextFactory;
            _serviceProvider = serviceProvider;
            _mapper = mapper;
            _context = context;
            _userServiceBLL = userServiceBLL;
        }

        public async Task<ResultUserDto?> LoadAsync(Guid userId, List<string> selectedFields)
        {
            //_fieldsCache[userId] = selectedFields;
            return await LoadAsync(userId);
        }

        protected override async Task<IReadOnlyDictionary<Guid, ResultUserDto>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            // `_fieldsCache` içindeki değerleri al
            var selectedFields = keys
                .Where(_fieldsCache.ContainsKey)
                .Select(key => _fieldsCache[key])
                .FirstOrDefault() ?? new List<string>();

            // `Id` alanını zorunlu ekleyelim (aksi takdirde ilişkili kullanıcıyı çekemeyebiliriz)
            if (!selectedFields.Any(f => f.Equals(nameof(ResultUserDto.Id), StringComparison.OrdinalIgnoreCase)))
            {
                selectedFields.Add(nameof(ResultUserDto.Id));
            }

            await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);

            var users = await context.Users
                .Where(u => keys.Contains(u.Id))
                .Select(u => new ResultUserDto
                {
                    Id = u.Id,
                    Email = u.Email,
                    UserName = u.UserName
                })
                .ToListAsync(cancellationToken);

            return users.ToDictionary(u => u.Id);
        }


        private static Expression<Func<User, ResultUserDto>> SelectFieldsExpression(List<string> selectedFields)
        {
            var parameter = Expression.Parameter(typeof(User), "u");
            var bindings = new List<MemberBinding>();

            foreach (var fieldName in selectedFields)
            {
                var userProperty = typeof(User).GetProperty(fieldName);
                var dtoProperty = typeof(ResultUserDto).GetProperty(fieldName);

                if (userProperty != null && dtoProperty != null)
                {
                    var propertyAccess = Expression.Property(parameter, userProperty);
                    bindings.Add(Expression.Bind(dtoProperty, propertyAccess));
                }
            }

            // Eğer hiçbir alan seçilmemişse, en azından Id'yi seçelim (boş bir query dönmemesi için)
            if (!bindings.Any())
            {
                var idProperty = typeof(User).GetProperty(nameof(ResultUserDto.Id));
                var idDtoProperty = typeof(ResultUserDto).GetProperty(nameof(ResultUserDto.Id));

                if (idProperty != null && idDtoProperty != null)
                {
                    var idAccess = Expression.Property(parameter, idProperty);
                    bindings.Add(Expression.Bind(idDtoProperty, idAccess));
                }
            }

            var body = Expression.MemberInit(Expression.New(typeof(ResultUserDto)), bindings);
            return Expression.Lambda<Func<User, ResultUserDto>>(body, parameter);
        }




    }
}
