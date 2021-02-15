using System;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.TimeManagement.CRST
{
    internal class SimplePlannerStrategy : AbstractCRSTStrategy
    {
        internal override bool TryGenerateTrackers(DateTime startDate, DateTime finishDate, ScheduleSettings schedule)
        {
            var finalDate = finishDate.Date.AddDays(1).AddSeconds(-1);
            var date = schedule.ScheduledCompletionDate ?? schedule.CompletionDate ?? finalDate;

            if (date.Date >= startDate && date.Date <= finalDate)
            {
                SetTracker(schedule.Trackers, date);
                return true;
            }

            return false;
        }
    }
}