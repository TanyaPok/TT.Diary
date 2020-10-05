namespace TT.Diary.BusinessLogic.DTO.TimeManagement
{
    public abstract class AbstractComponent
    {
        public int Id { get; set; }

        public string Description { set; get; }

        public int ParentCategoryId { get; set; }

        public string ParentCategoryDescription { get; set; }
    }
}