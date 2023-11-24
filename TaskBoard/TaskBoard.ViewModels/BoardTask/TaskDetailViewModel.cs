namespace TaskBoard.ViewModels.BoardTask
{
    public class TaskDetailViewModel : BoardTaskViewModel
    {
        public string CreatedOn { get; set; } = null!;

        public string Board { get; set; } = null!;
    }
}
