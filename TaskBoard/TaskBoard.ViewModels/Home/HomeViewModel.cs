namespace TaskBoard.ViewModels.Home
{
	public class HomeViewModel
	{
        public HomeViewModel()
        {
            this.BoardsWithTasksCount = new HashSet<HomeBoardModel>();
        }

        public int AllTasksCount { get; set; }

		public ICollection<HomeBoardModel> BoardsWithTasksCount { get; set; }

		public int UserTasksCount { get; set; }
	}
}
