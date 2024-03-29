﻿namespace TaskBoard.Services
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
        private readonly IBoardService boardService;

        public TaskService(TaskBoardDbContext dbContext, IBoardService boardService)
        {
            this.dbContext = dbContext;
            this.boardService = boardService;
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

		public async Task EditTaskAsync(int Id, string userId, TaskFormModel taskForm)
		{
            BoardTask task = await dbContext.Tasks.FirstAsync(t => t.Id == Id);

            if (task.OwnerId != userId)
            {
                throw new InvalidOperationException();
            }

            bool isBoardExisting = await boardService.IsBoadrdExistingAsync(taskForm);

			if (!isBoardExisting)
            {
				throw new InvalidOperationException();
			}

            task.Title = taskForm.Title;
            task.Description = taskForm.Description;
            task.BoardId = taskForm.BoardId;

            await dbContext.SaveChangesAsync();
		}

		public async Task<BoardTaskViewModel> DeleteTaskAsync(int Id, string userId, string userName)
		{
            BoardTask task = await dbContext.Tasks.FirstAsync(t => t.Id == Id);

            if (task.OwnerId != userId)
            {
                throw new InvalidOperationException();
            }

            BoardTaskViewModel viewModel = new BoardTaskViewModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Owner = userName
            };

            return viewModel;
		}

		public async Task DeleteTaskAsync(string userId, BoardTaskViewModel model)
		{
			BoardTask task = await dbContext.Tasks.FirstAsync(t => t.Id == model.Id);

            if (task.OwnerId != userId)
            {
                throw new InvalidOperationException();
            }

            dbContext.Tasks.Remove(task);
            await dbContext.SaveChangesAsync();
        }
	}
}
