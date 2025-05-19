using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries.Filters
{
    public class UserPublicSelfFilterType : UserCommonSelfFilterType
    {
        protected override void Configure(IFilterInputTypeDescriptor<User> descriptor)
        {
        }
    }
}
