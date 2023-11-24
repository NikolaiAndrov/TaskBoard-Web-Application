namespace TaskBoard.Services
{
	using Microsoft.EntityFrameworkCore;
	using TaskBoard.Data;
	using TaskBoard.Services.Interfaces;
	using TaskBoard.ViewModels.Home;

	public class HomeService : IHomeService
	{
		private readonly TaskBoardDbContext dbContext;

        public HomeService(TaskBoardDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		public async Task<HomeViewModel> DisplayHomeAsync(string userId)
		{
			HomeBoardModel[] homeBoardModel = await dbContext.Boards
				.Select(b => new HomeBoardModel
				{
					BoardName = b.Name,
					TasksCount = b.Tasks.Count()
				})
				.ToArrayAsync();

			int totalTasksCount = homeBoardModel.Sum(t => t.TasksCount);

			int userTasksCount = dbContext.Tasks.Count(t => t.OwnerId == userId);

			HomeViewModel homeViewModel = new HomeViewModel
			{
				AllTasksCount = totalTasksCount,
				BoardsWithTasksCount = homeBoardModel,
				UserTasksCount = userTasksCount
			};

			return homeViewModel;
		}
	}
}
