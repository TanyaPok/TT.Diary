using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class ToDoListContainerRepository : AbstractBaseContainerRepository<Category, ToDo>
    {
        public ToDoListContainerRepository(DiaryDBContext dbContext, ICategoryTitleList categoryTitleList) : base(
            dbContext, categoryTitleList.ToDoList)
        {
        }
    }
}