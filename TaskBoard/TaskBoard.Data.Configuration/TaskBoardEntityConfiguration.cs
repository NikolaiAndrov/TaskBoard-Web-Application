namespace TaskBoard.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TaskBoard.Data.Models;

    public class TaskBoardEntityConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            ICollection<Board> boards = this.CreateBoards();
            builder.HasData(boards);
        }

        private ICollection<Board> CreateBoards()
        {
            ICollection<Board> boards = new HashSet<Board>();

            Board board;

            board = new Board
            {
                Id = 1,
                Name = "Open"
            };
            boards.Add(board);

            board = new Board
            {
                Id = 2,
                Name = "In Progress"
            };
            boards.Add(board);

            board = new Board 
            {
                Id = 3,
                Name = "Done"
            };
            boards.Add(board);

            return boards;
        }
    }
}
