using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.DTO.TimeManagement
{
    public class PrioritizedActivity : NonPrioritizedActivity
    {
        public Priority Priority { get; set; }
    }
}