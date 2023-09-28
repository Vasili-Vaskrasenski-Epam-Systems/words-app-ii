using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class WordsDatabaseContext: DbContext, IDatabaseContext
    {
        public WordsDatabaseContext(DbContextOptions options) : base(options)
        {
            base.Database.EnsureCreated();
        }

        public DbSet<WordEntity> Words { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TaskWordEntity> TaskWords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WordEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Word).IsRequired();
                entity.Property(e => e.Translation).IsRequired();
                entity.HasMany(e => e.TaskWords).WithOne(ee => ee.Word).HasForeignKey(eee => eee.WordId);
            });

            modelBuilder.Entity<TaskEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.TaskName).IsRequired();
                entity.HasMany(e => e.TaskWords).WithOne(ee => ee.Task).HasForeignKey(eee => eee.TaskId);
            });

            modelBuilder.Entity<TaskWordEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
