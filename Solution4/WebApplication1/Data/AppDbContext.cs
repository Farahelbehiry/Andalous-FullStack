using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<TaskItem> TaskItem { get; set; }
        public DbSet<User> User { get; set; }
        public AppDbContext(DbContextOptions options):base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Name).IsRequired().HasMaxLength(50);


            });
            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Title).IsRequired().HasMaxLength(50);
                entity.Property(t => t.CreatedAt).HasDefaultValueSql("NOW()");


                entity.HasOne(t => t.User).WithMany(U => U.TaskItems).HasForeignKey(t => t.UserId);

                entity.HasIndex(t => t.UserId);
                entity.HasIndex(t => t.CreatedAt);

            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
