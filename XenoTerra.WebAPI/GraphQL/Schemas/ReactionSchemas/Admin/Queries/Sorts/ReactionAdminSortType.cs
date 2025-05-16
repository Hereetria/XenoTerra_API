using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries.Sorts
{
    public class ReactionAdminSortType : SortAdminInputType<Reaction>
    {
        protected override void Configure(ISortInputTypeDescriptor<Reaction> descriptor)
        {
        }
    }
}
