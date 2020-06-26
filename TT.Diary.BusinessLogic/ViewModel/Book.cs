using System;

namespace TT.Diary.BusinessLogic.ViewModel
{
    public class Book : IComponent
    {
        public int Id { set; get; }
        public string Description { set; get; }
        public string Author { set; get; }
        public DateTime CreatedDateUtc { set; get; }
    }
}