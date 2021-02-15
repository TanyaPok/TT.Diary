using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class ScheduleRepository : AbstractBaseRepository<ScheduleSettings>
    {
        public ScheduleRepository(DiaryDBContext dbContext) : base(dbContext)
        {
        }
    }
}