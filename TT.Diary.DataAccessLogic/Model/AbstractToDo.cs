using System.ComponentModel.DataAnnotations;

namespace TT.Diary.DataAccessLogic.Model
{
    public abstract class AbstractToDo : AbstractEntity
    {
        [Required(ErrorMessage = "Please enter Description")]
        public string Description { set; get; }
        public Schedule Schedule{set;get;}
    }
}