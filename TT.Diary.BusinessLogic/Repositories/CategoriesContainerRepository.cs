using System;
using System.Linq;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class CategoriesContainerRepository : AbstractBaseContainerRepository<Category, Category>
    {
        private readonly DiaryDBContext _dbContext;
        private readonly ICategoryTitleList _categoryTitleList;

        public CategoriesContainerRepository(DiaryDBContext dbContext, ICategoryTitleList categoryTitleList) : base(
            dbContext, categoryTitleList.Notes)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _categoryTitleList = categoryTitleList;
        }

        public bool IsRootCategory(int id)
        {
            var category = TryGet(e => e.Id == id);
            return (category.Description == _categoryTitleList.WishList
                    || category.Description == _categoryTitleList.ToDoList
                    || category.Description == _categoryTitleList.Habits
                    || category.Description == _categoryTitleList.Appointments
                    || category.Description == _categoryTitleList.PublicUtilities
                    || category.Description == _categoryTitleList.Notes)
                   && category.ParentId == null;
        }

        public bool HasChildren(int id)
        {
            return _dbContext.Categories.AsQueryable().Any(c => c.ParentId == id) ||
                   _dbContext.WishList.AsQueryable().Any(w => w.CategoryId == id) ||
                   _dbContext.ToDoList.AsQueryable().Any(w => w.CategoryId == id) ||
                   _dbContext.Habits.AsQueryable().Any(w => w.CategoryId == id) ||
                   _dbContext.Appointments.AsQueryable().Any(w => w.CategoryId == id) ||
                   _dbContext.Notes.AsQueryable().Any(w => w.CategoryId == id);
        }
    }
}