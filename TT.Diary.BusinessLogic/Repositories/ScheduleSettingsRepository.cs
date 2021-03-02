using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class ScheduleSettingsRepository : AbstractBaseRepository<ScheduleSettings>
    {
        public ScheduleSettingsRepository(DiaryDBContext dbContext) : base(dbContext)
        {
        }
    }
}
