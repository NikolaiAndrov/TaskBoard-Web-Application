namespace TaskBoard.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;
    using TaskBoard.Data.Configuration;
    using TaskBoard.Data.Models;

    public class TaskBoardDbContext : IdentityDbContext<IdentityUser>
	{
		public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
			: base(options)
		{
		}

		public DbSet<Board> Boards { get; set; } = null!;

		public DbSet<BoardTask> Tasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Board>(entity =>
            {
                entity.HasMany(b => b.Tasks)
                .WithOne(t => t.Board)
                .HasForeignKey(t => t.BoardId)  
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.ApplyConfiguration(new TaskBoardEntityConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
