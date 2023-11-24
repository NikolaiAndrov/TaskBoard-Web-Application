namespace TaskBoard.ViewModels.Board
{
    using TaskBoard.ViewModels.BoardTask;

    public class BoardViewModel
    {
        public BoardViewModel()
        {
            this.Tasks = new HashSet<BoardTaskViewModel>();
        }
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<BoardTaskViewModel> Tasks { get; set; }
    }
}
