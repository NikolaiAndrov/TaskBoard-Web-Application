namespace TaskBoard.Data
{
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;
    using TaskBoard.Data.Models;

    public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Board> Boards { get; set; } = null!;

		public DbSet<BoardTask> Tasks { get; set; } = null!;
	}
}
