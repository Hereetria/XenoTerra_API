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
                { typeof(BlockUser), typeof(BlockUserDataLoader) },
                { typeof(Comment), typeof(CommentDataLoader) },
                { typeof(Follow), typeof(FollowDataLoader) },
                { typeof(Highlight), typeof(HighlightDataLoader) },
                { typeof(PostLike), typeof(PostLikeDataLoader) },
                { typeof(Media), typeof(MediaDataLoader) },
                { typeof(Message), typeof(MessageDataLoader) },
                { typeof(Note), typeof(NoteDataLoader) },
                { typeof(Notification), typeof(NotificationDataLoader) },
                { typeof(Post), typeof(PostDataLoader) },
                { typeof(Reaction), typeof(ReactionDataLoader) },
                { typeof(RecentChats), typeof(RecentChatsDataLoader) },
                { typeof(ReportComment), typeof(ReportCommentDataLoader) },
                { typeof(AppRole), typeof(AppRoleDataLoader) },
                { typeof(SavedPost), typeof(SavedPostDataLoader) },
                { typeof(SearchHistory), typeof(SearchHistoryDataLoader) },
                { typeof(Story), typeof(StoryDataLoader) },
                { typeof(AppUser), typeof(AppUserDataLoader) },
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
