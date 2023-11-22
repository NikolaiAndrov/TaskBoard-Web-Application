namespace TaskBoard.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static TaskBoard.Common.ValidationConstants.Board;

    public class Board
    {
        public Board()
        {
            this.Tasks = new HashSet<BoardTask>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<BoardTask> Tasks { get; set; }
    }
}
