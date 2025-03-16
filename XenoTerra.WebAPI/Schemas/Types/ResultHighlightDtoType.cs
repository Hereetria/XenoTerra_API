using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.WebAPI.Schemas.DataLoaders;
using XenoTerra.WebAPI.Schemas.Resolvers;

namespace XenoTerra.WebAPI.Schemas.Types
{
    public class ResultHighlightDtoType : ObjectType<ResultHighlightWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultHighlightWithRelationsDto> descriptor)
        {
            descriptor
                .Field(x => x.Stories)
                .Resolve(async context =>
                {
                    var highlightDto = context.Parent<ResultHighlightWithRelationsDto>();
                    var highlightStoryDataLoader = context.Service<StoryHighlightDataLoader>();
                    var resolver = context.Service<HighlightResolver>();

                    await resolver.PopulateHighlightStoriesAsync(highlightDto, highlightStoryDataLoader, context);

                    return highlightDto.Stories;
                });
        }
    }

}
