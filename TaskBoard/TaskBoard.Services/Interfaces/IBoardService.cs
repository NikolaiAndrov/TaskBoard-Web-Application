namespace TaskBoard.Services.Interfaces
{
    using TaskBoard.ViewModels.Board;

    public interface IBoardService
    {
        Task<ICollection<BoardViewModel>> AllAsync();
    }
}
