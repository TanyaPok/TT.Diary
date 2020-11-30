using System.Collections.Generic;

namespace TT.Diary.BusinessLogic.DTO.Lists
{
    public class Category<T> where T : IItem
    {
        public int Id { get; set; }

        public string Description { set; get; }

        public IEnumerable<Category<T>> Subcategories { get; set; }

        public IList<T> Items { get; set; }

        internal void RemoveScheduledItems<C>() where C : AbstractScheduledItem
        {
            for (var i = Items.Count - 1; i >= 0; i--)
            {
                var item = Items[i] as C;

                if (item == null)
                {
                    continue;
                }

                if (item.HasSchedule)
                {
                    Items.Remove(Items[i]);
                }
            }

            foreach (var child in Subcategories)
            {
                child.RemoveScheduledItems<C>();
            }
        }
    }
}