using System.ComponentModel;

namespace TT.Diary.BusinessLogic.Configurations
{
    //TODO: review messages. make usable
    public enum ValidationMessages
    {
        [Description("Please set description.")]
        DescriptionEmpty,
        [Description("Cannot be nested within itself.")]
        InvalidParent,
        [Description("Has nested items. Please remove them in the beginning.")]
        HasNestedItems,
        [Description("Please set category.")]
        InvalidCategoryId,
        [Description("Invalid identifier format.")]
        InvalidId,
        [Description("Please set owner of schedule settings.")]
        InvalidOwnerScheduleSettingsId,
        [Description("Wish is on schedule.")]
        WishOnSchedule,
        [Description("Habit is on schedule.")]
        HabitOnSchedule,
        [Description("ToDo is on schedule.")]
        ToDoOnSchedule,
        [Description("Schedule mode is not set.")]
        NotSetRepeat,
        [Description("Custom schedule mode is incorrect.")]
        IncorrectCustomRepeatMode
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
        RemoveHabit,
        [Description("ToDo cannot be recieved")]
        GetToDo,
        [Description("ToDo cannot be saved")]
        SaveToDo,
        [Description("ToDo cannot be removed")]
        RemoveToDo,
        [Description("Public Utilities cannot be saved")]
        SavePublicUtilities,
        [Description("Incorrect category of public utilities")]
        IncorrectPublicUtilitiesCategoryId,
        [Description("Incorrect category of meter reading")]
        IncorrectMeterReadingCategoryId,
        [Description("Meter reading cannot be saved")]
        SaveMeterReading,
        [Description("Settings cannot be saved")]
        SaveSettings,
        [Description("Settings cannot be recieved")]
        GetSettings
    }
}