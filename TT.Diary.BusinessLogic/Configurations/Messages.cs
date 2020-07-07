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
        [Description("Wish is on schedule.")]
        WishOnSchedule,
        [Description("Habit is on schedule.")]
        HabitOnSchedule
    }

    public enum ErrorMessages
    {
        [Description("Category cannot be recieved")]
        GetCategory,
        [Description("Category cannot be saved")]
        SaveCategory,
        [Description("Category cannot be removed")]
        RemovedCategory,
        [Description("Category items cannot be recieved")]
        GetCategoryItems,
        [Description("Wish cannot be recieved")]
        GetWish,
        [Description("Wish cannot be saved")]
        SaveWish,
        [Description("Wish cannot be removed")]
        RemoveWish,
        [Description("Habit cannot be recieved")]
        GetHabit,
        [Description("Habit cannot be saved")]
        SaveHabit,
        [Description("Habit cannot be removed")]
        RemoveHabit
    }
}