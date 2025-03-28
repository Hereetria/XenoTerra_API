using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.UserQueries.Filters
{
    public class UserFilterType : FilterInputType<User>
    {
        protected override void Configure(IFilterInputTypeDescriptor<User> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.Id);
            descriptor.Field(f => f.FullName);
            descriptor.Field(f => f.Bio);
            descriptor.Field(f => f.ProfilePicture);
            descriptor.Field(f => f.Website);
            descriptor.Field(f => f.BirthDate);
            descriptor.Field(f => f.FollowersCount);
            descriptor.Field(f => f.FollowingCount);
            descriptor.Field(f => f.IsVerified);
            descriptor.Field(f => f.LastActive);

            descriptor.Field(f => f.BlockedUsers)
                .Type<BlockUserNestedFilterType>();

            descriptor.Field(f => f.BlockingUsers)
                .Type<BlockUserNestedFilterType>();

            descriptor.Field(f => f.Posts)
                .Type<PostNestedFilterType>();

            descriptor.Field(f => f.Followers)
                .Type<FollowNestedFilterType>();

            descriptor.Field(f => f.Followings)
                .Type<FollowNestedFilterType>();

            descriptor.Field(f => f.Likes)
                .Type<LikeNestedFilterType>();

            descriptor.Field(f => f.Comments)
                .Type<CommentNestedFilterType>();

            descriptor.Field(f => f.SentMessages)
                .Type<MessageNestedFilterType>();

            descriptor.Field(f => f.ReceivedMessages)
                .Type<MessageNestedFilterType>();

            descriptor.Field(f => f.Notifications)
                .Type<NotificationNestedFilterType>();

            descriptor.Field(f => f.Medias)
                .Type<MediaNestedFilterType>();

            descriptor.Field(f => f.Stories)
                .Type<StoryNestedFilterType>();

            descriptor.Field(f => f.SavedPosts)
                .Type<SavedPostNestedFilterType>();

            descriptor.Field(f => f.ReportComments)
                .Type<ReportCommentNestedFilterType>();

            descriptor.Field(f => f.ViewStories)
                .Type<ViewStoryNestedFilterType>();

            descriptor.Field(f => f.UserSettings)
                .Type<UserSettingNestedFilterType>();

            descriptor.Field(f => f.SearchedBy)
                .Type<SearchHistoryUserNestedFilterType>();

            descriptor.Field(f => f.RecentChats)
                .Type<RecentChatsNestedFilterType>();

            descriptor.Field(f => f.Note)
                .Type<NoteNestedFilterType>();

            descriptor.Field(f => f.Reactions)
                .Type<ReactionNestedFilterType>();

            descriptor.Field(f => f.TaggedPosts)
                .Type<UserPostTagNestedFilterType>();
        }
    }
}
