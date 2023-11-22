namespace TaskBoard.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static TaskBoard.Common.ValidationConstants.BoardTask;

    public class BoardTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }

        [ForeignKey(nameof(BoardId))]
        public virtual Board Board { get; set; } = null!;

        [Required]
        public string OwnerId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(OwnerId))]
        public virtual IdentityUser Owner { get; set; } = null!;
    }
}
