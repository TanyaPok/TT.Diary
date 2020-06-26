using System;
using System.ComponentModel.DataAnnotations;

namespace TT.Diary.DataAccessLogic.Model
{
    public enum Rating
    {
        Empty,
        Trash,
        NotSoBad,
        Normal,
        Good,
        Fire
    }
    public class Book : Entity
    {
        public string Author { set; get; }
        [Required(ErrorMessage = "Please enter Description")]
        public string Description { set; get; }
        [Required(ErrorMessage = "Please enter CreatedDate")]
        public DateTime CreatedDateUtc { set; get; }
        public Rating Rating { set; get; }
        public Schedule Schedule { set; get; }
    }
}