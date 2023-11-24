namespace TaskBoard.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using System.Diagnostics;
	using System.Security.Claims;
	using TaskBoard.Services.Interfaces;
	using TaskBoard.ViewModels;
	using TaskBoard.ViewModels.Home;

	[Authorize]
	public class HomeController : Controller
	{
		private readonly IHomeService homeService;

		public HomeController(IHomeService homeService)
		{
			this.homeService = homeService;
		}

		public async Task<IActionResult> Index()
		{
			string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
			HomeViewModel model = await homeService.DisplayHomeAsync(userId);

			return View(model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
