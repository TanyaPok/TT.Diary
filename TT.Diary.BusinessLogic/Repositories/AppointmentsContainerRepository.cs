using System.Linq;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class AppointmentsContainerRepository : AbstractBaseTrackedItemRepository<Appointment>
    {
        public AppointmentsContainerRepository(DiaryDBContext dbContext, ICategoryTitleList categoryTitleList) : base(
            dbContext, categoryTitleList.Appointments, c => c.Appointments.Where(s => s.Schedule == null))
        {
        }
    }
}