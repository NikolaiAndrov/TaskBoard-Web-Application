namespace TaskBoard.Common
{
    public static class ValidationConstants
    {
        public static class BoardTask
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 70;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;

            public const string TitleErrorMessge = $"The title should be between 5 and 70 characters long!";
            public const string DescriptionErrorMessage = "The description should be between 10 and 1000 characters long";
        }

        public static class Board
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 30;
        }
    }
}
