using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class SavedPostNestedFilterType : FilterInputType<SavedPost>
    {
        protected override void Configure(IFilterInputTypeDescriptor<SavedPost> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.SavedPostId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.SavedAt);
        }
    }
}
