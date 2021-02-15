using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.DTO.Lists
{
    public class Habit<T> : AbstractScheduledItem<T> where T : AbstractScheduleSettings
    {
        public uint? Amount { get; set; }
    }
}