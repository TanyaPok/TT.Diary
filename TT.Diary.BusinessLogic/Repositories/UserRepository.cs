using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class UserRepository : AbstractBaseRepository<User>
    {
        private readonly ICategoryTitleList _categoryTitleList;

        public UserRepository(DiaryDBContext dbContext, ICategoryTitleList categoryTitleList) : base(dbContext)
        {
            _categoryTitleList = categoryTitleList ?? throw new ArgumentNullException(nameof(categoryTitleList));
        }

        public override async Task AddAsync(User item, CancellationToken cancellationToken)
        {
            Configure(item);
            await base.AddAsync(item, cancellationToken);
        }

        private void Configure(User user)
        {
            user.Categories.Add(new Category {Description = _categoryTitleList.ToDoList});
            user.Categories.Add(new Category {Description = _categoryTitleList.Appointments});
            user.Categories.Add(new Category {Description = _categoryTitleList.Habits});
            user.Categories.Add(new Category {Description = _categoryTitleList.PublicUtilities});
            user.Categories.Add(new Category {Description = _categoryTitleList.WishList});
            user.Categories.Add(new Category {Description = _categoryTitleList.Notes});
        }
    }
}