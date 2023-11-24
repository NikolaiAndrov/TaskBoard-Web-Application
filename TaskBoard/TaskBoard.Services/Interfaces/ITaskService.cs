namespace TaskBoard.Services.Interfaces
{
    using TaskBoard.ViewModels.BoardTask;

    public interface ITaskService
    {
        Task CreateTaskAsync(TaskFormModel model, string ownerId);

        Task<TaskDetailViewModel> TaskInfoAsync(int Id);

        Task<TaskFormModel> GetByIdForEdit(int Id, string userId);

        Task EditTaskAsync(int Id, string userId, TaskFormModel taskForm);
    }
}
