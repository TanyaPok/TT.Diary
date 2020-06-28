using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace TT.Diary.BusinessLogic.ViewModel
{
    public class Category : IComponent
    {
        public int Id { set; get; }
        public string Description { set; get; }
        [JsonIgnore]
        public IList<IComponent> Children { set; get; }
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
    }
}