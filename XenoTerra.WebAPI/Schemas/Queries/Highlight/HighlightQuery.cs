using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.HighlightServices;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.Highlight
{
    public class HighlightQuery
    {
        public async Task<IEnumerable<ResultHighlightWithRelationsDto>> GetHighlightsAsync(
            List<Guid>? ids,
            [Service] IHighlightServiceBLL service,
            IResolverContext context)
        {
            var selectedFields = context.Selection.SyntaxNode.SelectionSet?.Selections
                .OfType<FieldNode>()
                .Select(s => s.Name.Value)
                .ToList() ?? new List<string>();

            var result = await service.GetByIdsWithRelationsAsync(
                ids ?? await service.GetAllIdsAsync(),
                selectedFields
            );

            return result;
        }

        //[UseProjection]
        //[GraphQLDescription("Get all Highlights")]
        //public IQueryable<ResultHighlightDto> GetAllHighlights([Service] IHighlightServiceBLL highlightServiceBLL)
        //{
        //    return highlightServiceBLL.GetAllQuerable();
        //}

        //[UseProjection]
        //[GraphQLDescription("Get Highlight by ID")]
        //public IQueryable<ResultHighlightByIdDto> GetHighlightById(Guid id, [Service] IHighlightServiceBLL highlightServiceBLL)
        //{
        //    var result = highlightServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"Highlight with ID {id} not found");
        //    }
        //    return result;
        //}
    }
}
