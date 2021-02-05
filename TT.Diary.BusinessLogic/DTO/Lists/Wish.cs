using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.DTO.Lists
{
    public class Wish<T> : AbstractScheduledItem<T> where T : AbstractScheduleSettings
    {
        public string Author { set; get; }

        public DataAccessLogic.Model.TypeList.Rating Rating { set; get; }
    }
}