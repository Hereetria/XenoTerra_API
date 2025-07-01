using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries.Filters
{
    public class UserPostTagOwnFilterType : FilterInputType<UserPostTag>
    {
        protected override void Configure(IFilterInputTypeDescriptor<UserPostTag> descriptor)
        {
        descriptor.Name("UserPostTagOwnFilterInput");
        }
    }
}
