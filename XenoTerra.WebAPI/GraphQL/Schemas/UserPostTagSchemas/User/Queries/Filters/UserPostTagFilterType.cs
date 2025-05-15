using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Filters
{
    public class UserPostTagFilterType : FilterInputType<UserPostTag>
    {
        protected override void Configure(IFilterInputTypeDescriptor<UserPostTag> descriptor)
        {
        }
    }
}
