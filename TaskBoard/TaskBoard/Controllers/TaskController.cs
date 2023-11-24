namespace TaskBoard.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using TaskBoard.Services.Interfaces;
	using TaskBoard.ViewModels.Board;
	using TaskBoard.ViewModels.BoardTask;

	[Authorize]
	public class TaskController : Controller
	{
		private readonly IBoardService boardService;
		private readonly ITaskService taskService;

        public TaskController(IBoardService boardService, ITaskService taskService)
        {
            this.boardService = boardService;
            this.taskService = taskService;

        }

        public async Task<IActionResult> Create()
		{
			ICollection<TaskBoardModel> boards = await boardService.GetBoardsForTaskCreatingAsync();

			TaskFormModel task = new TaskFormModel
			{
				Boards = boards
			};

			return View(task);
		}

		[HttpPost]
		public async Task<IActionResult> Create(TaskFormModel model)
		{
			bool exists = await boardService.IsBoadrdExistingAsync(model);

			if (!exists)
			{
				ModelState.AddModelError(nameof(model.BoardId), "Board does not exist");
			}

			if (!ModelState.IsValid)
			{
				model.Boards = await boardService.GetBoardsForTaskCreatingAsync();
                return View(model);
			}

			try
			{
				string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
				await taskService.CreateTaskAsync(model, userId);
			}
			catch (Exception)
			{
				return RedirectToAction("All", "Board");
			}

			return RedirectToAction("All", "Board");
        }

		public async Task<IActionResult> Details(int Id)
		{
			TaskDetailViewModel task;

            try
			{
				task = await taskService.TaskInfoAsync(Id);
			}
			catch (Exception)
			{
				return RedirectToAction("All", "Board");
			}

			return View(task);
		}
	}
}
