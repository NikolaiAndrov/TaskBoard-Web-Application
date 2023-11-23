namespace TaskBoard.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using TaskBoard.Services.Interfaces;
	using TaskBoard.ViewModels.Board;
	using TaskBoard.ViewModels.BoardTask;

	[Authorize]
	public class TaskController : Controller
	{
		private readonly IBoardService boardService;

        public TaskController(IBoardService boardService)
        {
            this.boardService = boardService;
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
	}
}
