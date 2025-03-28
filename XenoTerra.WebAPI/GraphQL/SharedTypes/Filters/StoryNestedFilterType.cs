using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class StoryNestedFilterType : FilterInputType<Story>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Story> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.StoryId);
            descriptor.Field(f => f.Path);
            descriptor.Field(f => f.IsVideo);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.CreatedAt);
        }
    }
}
