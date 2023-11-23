namespace TaskBoard.Services
{
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
    }
}
