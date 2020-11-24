using System;
using System.Collections.Generic;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.TimeManagement.CRST
{
    internal class SimplePlannerStrategy : CRSTStrategy
    {
        internal override bool TryGenerateTrackers(DateTime startDate, DateTime finishDate, ScheduleSettings schedule, IList<Tracker> trackers)
        {
            var finalDate = finishDate.Date.AddDays(1).AddSeconds(-1);
            var date = schedule.ScheduledCompletionDate ?? schedule.CompletionDate ?? finalDate;
            
            if (date.Date >= startDate && date.Date <= finalDate)
            {
                SetTracker(trackers, date);
                return true;
            }

            return false;
        }
    }
}
