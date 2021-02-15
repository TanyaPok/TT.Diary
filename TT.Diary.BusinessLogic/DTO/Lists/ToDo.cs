using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.DTO.Lists
{
    public class ToDo<T> : AbstractScheduledItem<T> where T : AbstractScheduleSettings
    {
    }
}