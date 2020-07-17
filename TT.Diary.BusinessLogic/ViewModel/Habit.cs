namespace TT.Diary.BusinessLogic.ViewModel
{
    public class Habit : AbstractComponent
    {
        public int? Amount { get; set; }
        public ScheduleSettings Settings { get; set; }
    }
}