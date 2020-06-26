using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TT.Diary.DataAccessLogic.Model
{
    public class Category : Entity
    {
        [Required(ErrorMessage = "Please enter Description")]
        public string Description { set; get; }
        public IList<Category> Subcategories { set; get; }
        public IList<Book> Books { set; get; }

        public void AddCategory(Category category)
        {
            this.Subcategories.Add(category);
        }
        public void RemoveCategory(Category category)
        {
            Subcategories.Remove(category);
        }
        public void AddBook(Book book)
        {
            this.Books.Add(book);
        }
        public void RemoveBook(Book book)
        {
            this.Books.Remove(book);
        }
        public bool HasCategory(int id)
        {
            if (this.Id == id)
            {
                return true;
            }

            var hasCategory = false;
            
            foreach (var category in this.Subcategories)
            {
                if (category.HasCategory(id))
                {
                    hasCategory = true;
                    break;
                }
            }

            return hasCategory;
        }
        public bool HasBook()
        {
            if (this.Books != null && this.Books.Count > 0)
            {
                return true;
            }

            var has = false;
            
            foreach (var category in this.Subcategories)
            {
                if (category.HasBook())
                {
                    has = true;
                    break;
                }
            }

            return has;
        }
    }
}