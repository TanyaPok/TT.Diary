using System.ComponentModel;

namespace TT.Diary.BusinessLogic.Configurations
{
    public enum ValidationMessages
    {
        [Description("Please set description.")]
        DescriptionEmpty,
        [Description("Cannot be nested within itself.")]
        InvalidParent,
        [Description("Has nested items. Please remove them in the beginning.")]
        HasNestedItems,
        [Description("Please set category.")]
        CategoryEmpty,
        [Description("Book is on schedule.")]
        BookOnSchedule
    }

    public enum ErrorMessages
    {
        [Description("Category cannot be recieved")]
        GetCategory,
        [Description("Category cannot be saved")]
        SaveCategory,
        [Description("Category cannot be removed")]
        RemovedCategory,
        [Description("Book cannot be recieved")]
        GetBook,
        [Description("Book cannot be saved")]
        SaveBook,
        [Description("Book cannot be removed")]
        RemoveBook,
        [Description("Books cannot be recieved")]
        GetBooks
    }
}