namespace TaskBoard.Services.Interfaces
{
	using TaskBoard.ViewModels.Home;

	public interface IHomeService
	{
		Task<HomeViewModel> DisplayHomeAsync(string userId);
	}
}
