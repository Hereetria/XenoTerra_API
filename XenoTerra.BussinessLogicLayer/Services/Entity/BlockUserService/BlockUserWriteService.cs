using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService
{
    public class BlockUserWriteService : WriteService<BlockUser, ResultBlockUserDto, CreateBlockUserDto, UpdateBlockUserDto, Guid>, IBlockUserWriteService
    {
        public BlockUserWriteService(IWriteRepository<BlockUser, Guid> repository, IMapper mapper, SelectorExpressionProvider<BlockUser, ResultBlockUserDto> selectorExpressionProvider) : base(repository, mapper, selectorExpressionProvider)
        {
        }
    }
}
