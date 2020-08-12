using System.Collections.Generic;
using TT.Diary.DataAccessLogic.Model.Framework;

namespace TT.Diary.DataAccessLogic.Model
{
    public class User : AbstractEntity
    {
        public string Name { get; set; }
        public string Sub { get; set; }
        public IList<Category> Categories { get; set; }

        public User()
        {
            Categories = new List<Category>();
        }
    }
}
