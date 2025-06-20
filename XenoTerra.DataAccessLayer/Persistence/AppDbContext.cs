

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using XenoTerra.DataAccessLayer.Helpers.Concrete;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Persistence
{
    
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser, AppRole, Guid>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoryHighlight>()
            .HasKey(sh => new { sh.StoryId, sh.HighlightId });

            modelBuilder.Entity<StoryHighlight>()
                .HasOne(sh => sh.Story)
                .WithMany(s => s.StoryHighlights)
                .HasForeignKey(sh => sh.StoryId);

            modelBuilder.Entity<StoryHighlight>()
                .HasOne(sh => sh.Highlight)
                .WithMany(h => h.StoryHighlights)
                .HasForeignKey(sh => sh.HighlightId);

            modelBuilder.Entity<Highlight>()
                .HasOne(h => h.User)
                .WithMany(u => u.Highlights)
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BlockUser>()
                .HasOne(b => b.BlockingUser)
                .WithMany(u => u.BlockedUsers)
                .HasForeignKey(b => b.BlockingUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BlockUser>()
                .HasOne(b => b.BlockedUser)
                .WithMany(u => u.BlockingUsers)
                .HasForeignKey(b => b.BlockedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Follower)
                .WithMany(u => u.Followings)
                .HasForeignKey(f => f.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Following)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Media>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMedias)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Media>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMedias)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostLike>()
                .HasOne(l => l.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(l => l.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostLike>()
                .HasOne(l => l.User)
                .WithMany(u => u.PostLikes)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.ParentComment)
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.ParentCommentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReportPost>()
                .HasOne(rp => rp.Post)
                .WithMany(p => p.ReportPosts)
                .HasForeignKey(rp => rp.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReportPost>()
                .HasOne(rp => rp.ReporterUser)
                .WithMany(u => u.ReportPosts)
                .HasForeignKey(rp => rp.ReporterUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StoryLike>()
    .HasOne(l => l.Story)
    .WithMany(s => s.StoryLikes)
    .HasForeignKey(l => l.StoryId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StoryLike>()
                .HasOne(l => l.User)
                .WithMany(u => u.StoryLikes)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReportStory>()
    .HasOne(rs => rs.Story)
    .WithMany(s => s.ReportStories)
    .HasForeignKey(rs => rs.StoryId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReportStory>()
                .HasOne(rs => rs.ReporterUser)
                .WithMany(u => u.ReportStories)
                .HasForeignKey(rs => rs.ReporterUserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<SavedPost>()
                .HasOne(sp => sp.Post)
                .WithMany(p => p.SavedPosts)
                .HasForeignKey(sp => sp.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SavedPost>()
                .HasOne(sp => sp.User)
                .WithMany(u => u.SavedPosts)
                .HasForeignKey(sp => sp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ViewStory>()
                .HasOne(vs => vs.Story)
                .WithMany(s => s.ViewStories)
                .HasForeignKey(vs => vs.StoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ViewStory>()
                .HasOne(vs => vs.User)
                .WithMany(s => s.ViewStories)
                .HasForeignKey(vs => vs.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // PostTag i�in Many-to-Many ili�ki ekleme
            modelBuilder.Entity<UserPostTag>()
                .HasKey(pt => new { pt.PostId, pt.UserId }); // Composite Key

            modelBuilder.Entity<UserPostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.TaggedUsers) // Post'un etiketlenmi� kullan�c�lar�
                .HasForeignKey(pt => pt.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserPostTag>()
                .HasOne(pt => pt.User)
                .WithMany(u => u.TaggedPosts) // Kullan�c�n�n etiketlendi�i postlar
                .HasForeignKey(pt => pt.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // SearchHistoryUser i�in Many-to-Many ili�ki ekleme
            modelBuilder.Entity<SearchHistoryUser>()
                .HasKey(shu => new { shu.SearchHistoryId, shu.UserId }); // Composite Key

            modelBuilder.Entity<SearchHistoryUser>()
                .HasOne(shu => shu.SearchHistory)
                .WithMany(sh => sh.SearchedUsers)
                .HasForeignKey(shu => shu.SearchHistoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SearchHistoryUser>()
                .HasOne(shu => shu.SearchHistory)
                .WithMany(sh => sh.SearchedUsers)  // SearchHistory'de ICollection<SearchHistoryUser> SearchedUsers olmal�
                .HasForeignKey(shu => shu.SearchHistoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // SearchHistoryUser: AppUser ile ba�lant� (WasSearchedBy)
            modelBuilder.Entity<SearchHistoryUser>()
                .HasOne(shu => shu.User)
                .WithMany(u => u.WasSearchedBy)
                .HasForeignKey(shu => shu.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Connection String Provider'dan al
                string connectionString = ConnectionStringProvider.GetConnectionString();

                // E�er connection string NULL veya bo� ise hata f�rlat
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("No valid connection string found from ConnectionStringProvider.");
                }

                optionsBuilder.UseSqlServer(connectionString);
            }
        }



        public DbSet<BlockUser> BlockUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Highlight> Highlights { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserPostTag> UserPostTags { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<RecentChats> RecentChatses { get; set; }
        public DbSet<ReportPost> ReportPosts { get; set; }
        public DbSet<ReportComment> ReportComments { get; set; }
        public DbSet<SavedPost> SavedPosts { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }
        public DbSet<SearchHistoryUser> SearchHistoryUsers { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<StoryHighlight> StoryHighlights { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<ViewStory> ViewStories { get; set; }

    }
}