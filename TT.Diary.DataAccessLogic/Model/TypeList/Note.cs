using System;

namespace TT.Diary.DataAccessLogic.Model.TypeList
{
    public class Note : AbstractComponent
    {
        #region DB settings
        public int CategoryId { set; get; }

        public Category Category { set; get; }
        #endregion

        public DateTime CreationDate { get; set; }
    }
}
