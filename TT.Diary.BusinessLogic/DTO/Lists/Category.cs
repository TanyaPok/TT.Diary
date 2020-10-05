using System.Collections.Generic;

namespace TT.Diary.BusinessLogic.DTO.Lists
{
    public class Category<T> where T : AbstractItem
    {
        public int Id { get; set; }

        public string Description { set; get; }

        public IEnumerable<Category<T>> Subcategories { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}