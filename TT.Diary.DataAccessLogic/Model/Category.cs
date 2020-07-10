using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TT.Diary.DataAccessLogic.Model.Framework;

namespace TT.Diary.DataAccessLogic.Model
{
    public class Category : AbstractComposite
    {
        public readonly string ARGUMENT_EXCEPTION = "Unexpected type {0}.";
        [NotMapped]
        public override IEnumerable<AbstractComponent> Children
        {
            get
            {
                return Subcategories
                    .Union<AbstractComponent>(WishList)
                    .Union<AbstractComponent>(Habits)
                    .Union<AbstractComponent>(ToDoList);
            }
        }

        public IList<Category> Subcategories { set; get; }

        public IList<Wish> WishList { set; get; }

        public IList<Habit> Habits { set; get; }

        public IList<ToDo> ToDoList { set; get; }

        public Category()
        {
            Subcategories = new List<Category>();
            WishList = new List<Wish>();
            Habits = new List<Habit>();
            ToDoList = new List<ToDo>();
        }

        public override void Add(AbstractComponent component)
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

        public override void Remove(AbstractComponent component)
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