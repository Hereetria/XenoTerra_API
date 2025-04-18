using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.ReactionQueries
{
    public class ReactionSortType : SortInputType<Reaction>
    {
        protected override void Configure(ISortInputTypeDescriptor<Reaction> descriptor)
        {
        }
    }
}
