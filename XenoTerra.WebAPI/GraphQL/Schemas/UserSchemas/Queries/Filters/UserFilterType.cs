using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.UserQueries.Filters
{
    public class UserFilterType : FilterInputType<User>
    {
        protected override void Configure(IFilterInputTypeDescriptor<User> descriptor)
        {
        }
    }
}
