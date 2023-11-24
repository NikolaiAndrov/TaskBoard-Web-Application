namespace TaskBoard.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using TaskBoard.Data;
    using TaskBoard.Data.Models;
    using TaskBoard.Services.Interfaces;
    using TaskBoard.ViewModels.BoardTask;

    public class TaskService : ITaskService
    {
        private readonly TaskBoardDbContext dbContext;

        public TaskService(TaskBoardDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateTaskAsync(TaskFormModel model, string ownerId)
        {
            BoardTask taskToAdd = new BoardTask
            {
                Title = model.Title,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                BoardId = model.BoardId,
                OwnerId = ownerId
            };

            await dbContext.Tasks.AddAsync(taskToAdd);
            await dbContext.SaveChangesAsync();
        }

		public async Task<TaskDetailViewModel> TaskInfoAsync(int Id)
        {
            TaskDetailViewModel task = await dbContext.Tasks
                .Where(t => t.Id == Id)
                .Select(t => new TaskDetailViewModel 
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("f"),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName!
                })
                .FirstAsync();

            return task;
        }

		public async Task<TaskFormModel> GetByIdForEdit(int Id, string userId)
		{
            BoardTask task = await dbContext.Tasks
                .FirstAsync(t => t.Id == Id);

            if (task.OwnerId != userId)
            {
                throw new InvalidOperationException();
            }

            TaskFormModel taskFormModel = new TaskFormModel
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId
            };

            return taskFormModel;
        }
	}
}
