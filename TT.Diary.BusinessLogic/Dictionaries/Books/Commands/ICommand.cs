namespace TT.Diary.BusinessLogic.Dictionaries.Books.Commands
{
    public interface ICommand
    {
        string Description { set; get; }
        int CategoryId { set; get; }
    }
}