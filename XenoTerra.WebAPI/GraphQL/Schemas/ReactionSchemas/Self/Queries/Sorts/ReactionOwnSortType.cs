using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries.Sorts
{
    public class ReactionOwnSortType : SortInputType<Reaction>
    {
        protected override void Configure(ISortInputTypeDescriptor<Reaction> descriptor)
        {
        descriptor.Name("ReactionOwnSortInput");
        }
    }
}
