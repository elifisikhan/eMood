using Entity;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Data.Concrete.EntityFramework
{
    public class eMoodContext : DbContext
    {
        public eMoodContext(DbContextOptions<eMoodContext> options)
            : base(options)
        {
        }
        public Microsoft.EntityFrameworkCore.DbSet<Activity> Activities { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Emotion> Emotions { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ActivityEmotion> ActivityEmotions { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ActivityAttribute> ActivityAttributes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityAttribute>()
                .HasOne<Activity>(s => s.Activity)
                .WithMany(g => g.ActivityAttributes)
                .HasForeignKey(s => s.ActivityID);
            modelBuilder.Entity<ActivityAttribute>()
                .HasOne<Emotion>(s => s.Emotion)
                .WithMany(g => g.ActivityAttributes)
                .HasForeignKey(s => s.EmotionID);

            modelBuilder.Entity<ActivityEmotion>()
                .HasKey(pk => new { pk.ActivityID, pk.EmotionID});

        }

    }
}
