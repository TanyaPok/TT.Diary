using TT.Diary.DataAccessLogic.Model.TimeManagement;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.DataAccessLogic.Model
{
    public abstract class AbstractItem : AbstractComponent
    {
        #region DB settings
        public int CategoryId { set; get; }
        public Category Category { set; get; }
        public int? ScheduleId { get; set; }
        #endregion
        public Schedule Schedule { get; set; }
    }
}