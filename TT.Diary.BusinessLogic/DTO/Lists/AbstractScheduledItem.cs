using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.DTO.Lists
{
    public abstract class AbstractScheduledItem<T> : AbstractCategoryItem where T : AbstractScheduleSettings
    {
        public bool IsTracked { get; set; }

        public T Schedule { get; set; }
    }
}