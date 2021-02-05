using System.Collections.Generic;

namespace TT.Diary.BusinessLogic.DTO.Lists
{
    public class Category<T> where T : AbstractCategoryItem
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Description { set; get; }

        public IEnumerable<Category<T>> Subcategories { get; set; }

        public IList<T> Items { get; set; }
    }
}