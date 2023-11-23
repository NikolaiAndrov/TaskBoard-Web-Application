namespace TaskBoard.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
	using System.Security.Claims;
	using TaskBoard.Services.Interfaces;
    using TaskBoard.ViewModels.Board;

    [Authorize]
    public class BoardController : Controller
    {
        private readonly IBoardService boardService;

        public BoardController(IBoardService boardService)
        {
            this.boardService = boardService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ICollection<BoardViewModel> boards = await this.boardService.AllAsync();
            return View(boards);
        }
    }
}
