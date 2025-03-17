using GreenDonut;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.Base;
using XenoTerra.WebAPI.Schemas.DataLoaders.Entity;

namespace XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories
{
    public class EntityDataLoaderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityDataLoaderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IEntityDataLoader<TKey, TEntity> GetDataLoader<TEntity, TKey>()
            where TEntity : class
            where TKey : notnull
        {
            var dataLoaderMappings = new Dictionary<Type, Type>
    {
        { typeof(BlockUser), typeof(BlockUserDataLoader) },
        { typeof(Comment), typeof(CommentDataLoader) },
        { typeof(Follow), typeof(FollowDataLoader) },
        { typeof(Highlight), typeof(HighlightDataLoader) },
        { typeof(Like), typeof(LikeDataLoader) },
        { typeof(Media), typeof(MediaDataLoader) },
        { typeof(Message), typeof(MessageDataLoader) },
        { typeof(Note), typeof(NoteDataLoader) },
        { typeof(Notification), typeof(NotificationDataLoader) },
        { typeof(Post), typeof(PostDataLoader) },
        { typeof(Reaction), typeof(ReactionDataLoader) },
        { typeof(RecentChats), typeof(RecentChatsDataLoader) },
        { typeof(ReportComment), typeof(ReportCommentDataLoader) },
        { typeof(Role), typeof(RoleDataLoader) },
        { typeof(SavedPost), typeof(SavedPostDataLoader) },
        { typeof(SearchHistory), typeof(SearchHistoryDataLoader) },
        { typeof(Story), typeof(StoryDataLoader) },
        { typeof(User), typeof(UserDataLoader) },
        { typeof(UserSetting), typeof(UserSettingDataLoader) },
        { typeof(ViewStory), typeof(ViewStoryDataLoader) }
    };

            if (!dataLoaderMappings.TryGetValue(typeof(TEntity), out var dataLoaderType))
            {
                throw new InvalidOperationException($"No DataLoader registered for entity type {typeof(TEntity).Name}");
            }

            var instance = _serviceProvider.GetService(dataLoaderType);

            if (instance == null)
            {
                throw new InvalidOperationException($"Failed to resolve DataLoader for type {dataLoaderType.Name}");
            }

            if (instance is not IEntityDataLoader<TKey, TEntity> entityDataLoader)
            {
                throw new InvalidCastException($"Resolved DataLoader is not of expected type IEntityDataLoader<{typeof(TKey).Name}, {typeof(TEntity).Name}>");
            }

            return entityDataLoader;
        }


    }
}
