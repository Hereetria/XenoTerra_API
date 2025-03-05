using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.BlockUserServices;
using XenoTerra.BussinessLogicLayer.Services.UserServices;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.Schemas.DataLoaders
{
    public class BlockUserDataLoader : BatchDataLoader<Guid, ResultBlockUserDto>
    {
        private readonly IBlockUserServiceBLL _blockUserServiceBLL;
        private readonly IUserServiceBLL _userServiceBLL;
        private readonly IMapper _mapper;
        public BlockUserDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, IBlockUserServiceBLL blockUserServiceBLL, IUserServiceBLL userServiceBLL, IMapper mapper) : base(batchScheduler, options)
        {
            _blockUserServiceBLL = blockUserServiceBLL;
            _userServiceBLL = userServiceBLL;
            _mapper = mapper;
        }

        protected override Task<IReadOnlyDictionary<Guid, ResultBlockUserDto>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
