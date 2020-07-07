using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace TT.Diary.BusinessLogic.ViewModel
{
    public class Category : AbstractComponent
    {
        [JsonIgnore]
        public IList<AbstractComponent> Children { set; get; }

        public IEnumerable<Category> Subcategories
        {
            get
            {
                return Children?.OfType<Category>();
            }
        }

        public IEnumerable<Wish> WishList
        {
            get
            {
                return Children?.OfType<Wish>();
            }
        }

        public IEnumerable<Habit> Habits
        {
            get
            {
                return Children?.OfType<Habit>();
            }
        }
    }
}