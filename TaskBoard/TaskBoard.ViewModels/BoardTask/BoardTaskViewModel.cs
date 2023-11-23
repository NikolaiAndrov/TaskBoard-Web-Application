namespace TaskBoard.ViewModels.BoardTask
{
    public class BoardTaskViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Owner { get; set; } = null!;
    }
}
