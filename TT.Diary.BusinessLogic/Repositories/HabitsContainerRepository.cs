using System.Linq;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class HabitsContainerRepository : AbstractBaseTrackedItemRepository<Habit>
    {
        public HabitsContainerRepository(DiaryDBContext dbContext, ICategoryTitleList categoryTitleList) : base(
            dbContext, categoryTitleList.Habits, c => c.Habits.Where(s => s.Schedule == null))
        {
        }
    }
}