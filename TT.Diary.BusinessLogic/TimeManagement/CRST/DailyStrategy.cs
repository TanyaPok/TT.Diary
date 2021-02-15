using System;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.TimeManagement.CRST
{
    internal class DailyStrategy : AbstractCRSTStrategy
    {
        internal override bool TryGenerateTrackers(DateTime startDate, DateTime finishDate, ScheduleSettings schedule)
        {
            var finish = GetFinishDate(finishDate, schedule.ScheduledCompletionDate, schedule.CompletionDate);
            var coefficient =
                Math.Ceiling((startDate.Date - schedule.ScheduledStartDateTime.Date).TotalDays / schedule.Every);
            var date = (coefficient < 0)
                ? schedule.ScheduledStartDateTime
                : schedule.ScheduledStartDateTime.AddDays(schedule.Every * coefficient);

            if (date > finish)
            {
                return false;
            }

            do
            {
                SetTracker(schedule.Trackers, date);
                date = date.AddDays(schedule.Every);
            } while (date <= finish);

            return true;
        }
    }
}