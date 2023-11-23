namespace TaskBoard.ViewModels.BoardTask
{
	using System.ComponentModel.DataAnnotations;
	using TaskBoard.ViewModels.Board;
	using static Common.ValidationConstants.BoardTask;

	public class TaskFormModel
	{
        public TaskFormModel()
        {
            this.Boards = new HashSet<TaskBoardModel>();
        }

        [Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = TitleErrorMessge)]
		public string Title { get; set; } = null!;

		[Required]
		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionErrorMessage)]
		public string Description { get; set; } = null!;

		[Display(Name = "Board")]
		public int BoardId { get; set; }

		public ICollection<TaskBoardModel> Boards { get; set; }
	}
}
