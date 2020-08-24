namespace TT.Diary.DataAccessLogic.Model
{
    public abstract class AbstractEntity
    {
        public const string ARGUMENT_EXCEPTION = "Unexpected type {0}.";
        public int Id { set; get; }
    }
}