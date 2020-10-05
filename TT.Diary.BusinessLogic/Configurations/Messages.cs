using System.ComponentModel;

namespace TT.Diary.BusinessLogic.Configurations
{
    public enum ValidationMessages
    {
        [Description("User's identificator cannot be empty.")]
        SubEmpty,
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
        [Description("Invalid user identifier format.")]
        InvalidUserId,
        [Description("Please set owner of schedule settings.")]
        InvalidOwnerScheduleSettingsId,
        [Description("Item is scheduled.")]
        IsScheduled,
        [Description("Schedule mode is not set.")]
        NotSetRepeat,
        [Description("Custom schedule mode is incorrect.")]
        IncorrectCustomRepeatMode,
        [Description("Root category cannot be removed.")]
        IsRootCategory
    }

    public enum ErrorMessages
    {
        [Description("User cannot be set")]
        SetUserUp,

        [Description("Category cannot be saved")]
        SaveCategory,
        [Description("Category cannot be removed")]
        RemovedCategory,
        [Description("Category items cannot be recieved")]
        GetCategoryItems,

        [Description("ToDo cannot be recieved")]
        GetToDo,
        [Description("To-do cannot be saved")]
        SaveToDo,
        [Description("To-do cannot be removed")]
        RemoveToDo,
        [Description("To-do list cannot be recieved")]
        GetToDoList,

        [Description("Wish cannot be recieved")]
        GetWish,
        [Description("Wish cannot be saved")]
        SaveWish,
        [Description("Wish cannot be removed")]
        RemoveWish,
        [Description("Wish list cannot be recieved")]
        GetWishList,

        [Description("Habit cannot be recieved")]
        GetHabit,
        [Description("Habit cannot be saved")]
        SaveHabit,
        [Description("Habit cannot be removed")]
        RemoveHabit,
        [Description("Habits cannot be recieved")]
        GetHabits,

        [Description("Note cannot be saved")]
        SaveNote,
        [Description("Note cannot be removed")]
        RemoveNote,
        [Description("Note list cannot be recieved")]
        GetNoteList,

        //TODO: review messages. make usable and seperate at least an empty row
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
        GetSettings,
        [Description("Scheduler cannot be recieved")]
        GetScheduler
    }
}