using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class WishListContainerRepository : AbstractBaseContainerRepository<Category, Wish>
    {
        public WishListContainerRepository(DiaryDBContext dbContext, ICategoryTitleList categoryTitleList) : base(
            dbContext, categoryTitleList.WishList)
        {
        }
    }
}