using System.Linq;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class ToDoListContainerRepository : AbstractBaseTrackedItemRepository<ToDo>
    {
        public ToDoListContainerRepository(DiaryDBContext dbContext, ICategoryTitleList categoryTitleList) : base(
            dbContext, categoryTitleList.ToDoList, c => c.ToDoList.Where(s => s.Schedule == null))
        {
        }
    }
}