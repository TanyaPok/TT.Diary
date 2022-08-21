using System.Collections.Generic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.MappingConfigurations
{
    public class PriorityComparer : IComparer<Priority>
    {
        public int Compare(Priority x, Priority y)
        {
            var x1 = (int) x;
            var y1 = (int) y;

            if (x1 == 0) return 1;
            if (y1 == 0) return -1;
            if (x1 < y1) return -1;
            return x1 > y1 ? 1 : 0;
        }
    }
}