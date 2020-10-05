using System.Collections.Generic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.DataAccessLogic.Model
{
    public class User : AbstractEntity
    {
        public string Name { get; set; }

        public string Sub { get; set; }

        public IList<Category> Categories { get; } = new List<Category>();
    }
}
