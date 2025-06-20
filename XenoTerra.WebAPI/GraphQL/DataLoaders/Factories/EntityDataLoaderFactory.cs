using GreenDonut;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.DataLoaders.Entity;

namespace XenoTerra.WebAPI.GraphQL.DataLoaders.Factories
{
    public class EntityDataLoaderFactory(IServiceProvider serviceProvider)
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public object GetDataLoader<TEntity>()
            where TEntity : class
        {
            var dataLoaderMappings = new Dictionary<Type, Type>
            {
                { typeof(AppRole), typeof(AppRoleDataLoader) },
                { typeof(AppUser), typeof(AppUserDataLoader) },
                { typeof(BlockUser), typeof(BlockUserDataLoader) },
                { typeof(Comment), typeof(CommentDataLoader) },
                { typeof(CommentLike), typeof(CommentLikeDataLoader) },
                { typeof(Follow), typeof(FollowDataLoader) },
                { typeof(Highlight), typeof(HighlightDataLoader) },
                { typeof(Media), typeof(MediaDataLoader) },
                { typeof(Message), typeof(MessageDataLoader) },
                { typeof(Note), typeof(NoteDataLoader) },
                { typeof(Notification), typeof(NotificationDataLoader) },
                { typeof(Post), typeof(PostDataLoader) },
                { typeof(PostLike), typeof(PostLikeDataLoader) },
                { typeof(Reaction), typeof(ReactionDataLoader) },
                { typeof(RecentChats), typeof(RecentChatsDataLoader) },
                { typeof(ReportComment), typeof(ReportCommentDataLoader) },
                { typeof(ReportPost), typeof(ReportPostDataLoader) },
                { typeof(ReportStory), typeof(ReportStoryDataLoader) },
                { typeof(SavedPost), typeof(SavedPostDataLoader) },
                { typeof(SearchHistory), typeof(SearchHistoryDataLoader) },
                { typeof(SearchHistoryUser), typeof(SearchHistoryUserDataLoader) },
                { typeof(Story), typeof(StoryDataLoader) },
                { typeof(StoryHighlight), typeof(StoryHighlightDataLoader) },
                { typeof(StoryLike), typeof(StoryLikeDataLoader) },
                { typeof(UserPostTag), typeof(UserPostTagDataLoader) },
                { typeof(UserSetting), typeof(UserSettingDataLoader) },
                { typeof(ViewStory), typeof(ViewStoryDataLoader) }
            };


            if (!dataLoaderMappings.TryGetValue(typeof(TEntity), out var dataLoaderType))
            {
                throw new InvalidOperationException($"No DataLoader registered for entity type {typeof(TEntity).Name}");
            }

            var instance = _serviceProvider.GetService(dataLoaderType);

            return instance ?? throw new InvalidOperationException($"Failed to resolve DataLoader for type {dataLoaderType.Name}");
        }
    }
}
