namespace TaskBoard.Services.Interfaces
{
    using TaskBoard.ViewModels.Board;
    using TaskBoard.ViewModels.BoardTask;

    public interface IBoardService
    {
        Task<ICollection<BoardViewModel>> AllAsync();

        Task<ICollection<TaskBoardModel>> GetBoardsForTaskCreatingAsync();

        Task<bool> IsBoadrdExistingAsync(TaskFormModel model);
    }
}
