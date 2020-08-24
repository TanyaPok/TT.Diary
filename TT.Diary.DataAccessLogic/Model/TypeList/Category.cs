using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TT.Diary.DataAccessLogic.Model.PublicUtilities;

namespace TT.Diary.DataAccessLogic.Model.TypeList
{
    public class Category : AbstractComponent
    {
        //TODO: remove
        [NotMapped]
        public IEnumerable<AbstractComponent> Children
        {
            get
            {
                return Subcategories
                    .Union<AbstractComponent>(WishList)
                    .Union<AbstractComponent>(Habits)
                    .Union<AbstractComponent>(ToDoList);
            }
        }

        #region DB settings
        public int UserId { set; get; }
        public User User { set; get; }
        public int? ParentId { set; get; }
        public Category Parent { set; get; }
        #endregion

        public IList<Category> Subcategories { get;} = new List<Category>();

        public IList<Wish> WishList { get; } =  new List<Wish>();

        public IList<Habit> Habits { get; } = new List<Habit>();

        public IList<ToDo> ToDoList { get; } = new List<ToDo>();

        public IList<Note> Notes { get; } = new List<Note>();

        public IList<Appointment> Appointments { get; } = new List<Appointment>();

        public IList<PublicUtility> PublicUtilities { get; } = new List<PublicUtility>();

        public bool Has(Func<Category, bool> func)
        {
            if (func.Invoke(this))
            {
                return true;
            }

            var has = false;

            foreach (var child in Subcategories)
            {
                if (child.Has(func))
                {
                    has = true;
                    break;
                }
            }

            return has;
        }

        public void Add(AbstractComponent component)
        {
            switch (component)
            {
                case Category category:
                    Subcategories.Add(category);
                    break;
                case Wish wish:
                    WishList.Add(wish);
                    break;
                case Habit habit:
                    Habits.Add(habit);
                    break;
                case ToDo toDo:
                    ToDoList.Add(toDo);
                    break;
                default:
                    throw new ArgumentException(string.Format(ARGUMENT_EXCEPTION, component));
            }
        }

        public void Remove(AbstractComponent component)
        {
            switch (component)
            {
                case Category category:
                    Subcategories.Remove(category);
                    break;
                default:
                    throw new ArgumentException(string.Format(ARGUMENT_EXCEPTION, component));
            }
        }
    }
}