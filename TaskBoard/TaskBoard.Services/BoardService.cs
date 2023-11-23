namespace TaskBoard.Services
{
    using Microsoft.EntityFrameworkCore;
    using TaskBoard.Data;
    using TaskBoard.Services.Interfaces;
    using TaskBoard.ViewModels.Board;
    using TaskBoard.ViewModels.BoardTask;

    public class BoardService : IBoardService
    {
        private readonly TaskBoardDbContext dbContext;

        public BoardService(TaskBoardDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<BoardViewModel>> AllAsync()
        {
            ICollection<BoardViewModel> boards = await dbContext.Boards
                .Select(b => new BoardViewModel
                {
                    Name = b.Name,
                    Tasks = b.Tasks
                    .Select(t => new BoardTaskViewModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName!
                    })
                    .ToArray()
                })
                .ToArrayAsync();

            return boards;
        }

		public async Task<ICollection<TaskBoardModel>> GetBoardsForTaskCreatingAsync()
		{
            ICollection<TaskBoardModel> boards = await dbContext.Boards
                .Select(b => new TaskBoardModel
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToArrayAsync();

            return boards;
		}

        public async Task<bool> IsBoadrdExistingAsync(TaskFormModel model)
        {
            return await dbContext.Boards.AnyAsync(b => b.Id == model.BoardId);
        }
    }
}
