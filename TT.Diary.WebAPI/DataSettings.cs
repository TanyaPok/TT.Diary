using TT.Diary.DataAccessLogic;

namespace TT.Diary.WebAPI
{
    public class DataSettings : IDataSettings
    {
        public int PublicUtilitiesCategoryId { get; set; }
        public int MeterReadingCategoryId { get; set; }
    }
}
