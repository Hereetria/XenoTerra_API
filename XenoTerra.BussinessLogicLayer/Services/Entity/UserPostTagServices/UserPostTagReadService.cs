using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserPostTagServices
{
    public class UserPostTagReadService(IReadRepository<UserPostTag, Guid> readRepository)
        : ReadService<UserPostTag, Guid>(readRepository), IUserPostTagReadService
    {
    }
}
