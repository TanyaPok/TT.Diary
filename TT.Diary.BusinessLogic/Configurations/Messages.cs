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
        [Description("Please set category.")] InvalidCategoryId,

        [Description("Invalid identifier format.")]
        InvalidId,

        [Description("Invalid user identifier format.")]
        InvalidUserId,

        [Description("Please set owner of schedule settings.")]
        InvalidOwnerScheduleSettingsId,

        [Description("Gap between periods must be greater 0.")]
        InvalidPeriodsGap,
        [Description("Item is scheduled.")] IsScheduled,

        [Description("Root category cannot be removed.")]
        IsRootCategory,
        [Description("Date not specified.")] NotSetDateTime,

        [Description("{0} has a range of values which does not include {1}.")]
        EnumOutOfRange,

        [Description("Please set owner of tracker.")]
        InvalidOwnerTrackerId
    }

    public enum ErrorMessages
    {
        [Description("User cannot be set")] SetUserUp,

        [Description("Category cannot be saved")]
        SaveCategory,

        [Description("Category cannot be removed")]
        RemovedCategory,

        [Description("Appointment cannot be recieved")]
        GetAppointment,

        [Description("Appointment cannot be saved")]
        SaveAppointment,

        [Description("Appointment cannot be removed")]
        RemoveAppointment,

        [Description("Appointments cannot be recieved")]
        GetAppointments,

        [Description("To-do list cannot be recieved")]
        GetToDoList,

        [Description("ToDo cannot be recieved")]
        GetToDo,

        [Description("To-do cannot be saved")] SaveToDo,

        [Description("To-do cannot be removed")]
        RemoveToDo,

        [Description("Wish cannot be recieved")]
        GetWish,
        [Description("Wish cannot be saved")] SaveWish,

        [Description("Wish cannot be removed")]
        RemoveWish,

        [Description("Wish list cannot be recieved")]
        GetWishList,

        [Description("Habit cannot be recieved")]
        GetHabit,
        [Description("Habit cannot be saved")] SaveHabit,

        [Description("Habit cannot be removed")]
        RemoveHabit,

        [Description("Habits cannot be recieved")]
        GetHabits,

        [Description("Note cannot be saved")] SaveNote,

        [Description("Note cannot be removed")]
        RemoveNote,

        [Description("Note list cannot be recieved")]
        GetNoteList,

        [Description("Schedule cannot be recieved")]
        GetPlanner,

        [Description("Annual productivity cannot be recieved")]
        GetAnnualProductivity,

        [Description("Schedule settings cannot be saved")]
        SaveScheduleSettings,

        [Description("Schedule settings cannot be removed")]
        RemoveScheduleSettings,

        [Description("Tracker cannot be saved")]
        SaveTracker,

        [Description("Tracker cannot be removed")]
        RemoveTracker,

        [Description("Non-prioritized activities cannot be recieved")]
        NonPrioritizedActivity,
        
        [Description("Prioritized activities cannot be recieved")]
        PrioritizedActivity,
        
        [Description("Priority cannot be saved")]
        SavePriority
    }
}