using System.Linq;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class WishListContainerRepository : AbstractBaseScheduledItemRepository<Wish>
    {
        public WishListContainerRepository(DiaryDBContext dbContext, ICategoryTitleList categoryTitleList) : base(
            dbContext, categoryTitleList.WishList, c => c.WishList.Where(s => s.Schedule == null))
        {
        }
    }
}