using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public interface IDatabaseContext
    {
        public DbSet<WordEntity> Words { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TaskWordEntity> TaskWords { get; set; }
    }
}
