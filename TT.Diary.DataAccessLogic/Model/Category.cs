using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TT.Diary.DataAccessLogic.Model
{
    public class Category : AbstractEntity
    {
        [Required(ErrorMessage = "Please enter Description")]
        public string Description { set; get; }
        public IList<Category> Subcategories { set; get; }
        public IList<Wish> Wishes { set; get; }
        public IList<Habit> Habits { set; get; }
        public IList<ToDo> ToDoList { set; get; }
        public void AddCategory(Category category)
        {
            Subcategories.Add(category);
        }
        public void RemoveCategory(Category category)
        {
            Subcategories.Remove(category);
        }
        public bool HasCategory(int id)
        {
            if (Id == id)
            {
                return true;
            }

            var hasCategory = false;

            foreach (var category in Subcategories)
            {
                if (category.HasCategory(id))
                {
                    hasCategory = true;
                    break;
                }
            }

            return hasCategory;
        }

        public void AddWish(Wish wish)
        {
            Wishes.Add(wish);
        }

        public bool HasItem()
        {
            if (Wishes != null && Wishes.Count > 0 ||
                Habits != null && Habits.Count > 0 ||
                ToDoList != null && ToDoList.Count > 0)
            {
                return true;
            }

            var has = false;

            foreach (var category in Subcategories)
            {
                if (category.HasItem())
                {
                    has = true;
                    break;
                }
            }

            return has;
        }
    }
}