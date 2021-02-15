using System;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.TimeManagement.CRST
{
    internal class MonthlyStrategy : AbstractCRSTStrategy
    {
        internal override bool TryGenerateTrackers(DateTime startDate, DateTime finishDate, ScheduleSettings schedule)
        {
            var date = schedule.ScheduledStartDateTime;
            var finish = GetFinishDate(finishDate, schedule.ScheduledCompletionDate, schedule.CompletionDate);
            var startDay = date.Day - 1;

            while (date.AddDays(schedule.DaysAmount) < startDate)
            {
                date = GetNextDate(date, schedule.Every, startDay);
            }

            if (date > finish)
            {
                return false;
            }

            do
            {
                SetTracker(schedule.Trackers, date);
                date = GetNextDate(date, schedule.Every, startDay);
            } while (date <= finish);

            return true;
        }

        private DateTime GetNextDate(DateTime date, uint every, int startDay)
        {
            date = date.AddDays(DateTime.DaysInMonth(date.Year, date.Month) - date.Day + 1);
            date = date.AddMonths((int) every - 1);
            date = date.AddDays(startDay);
            return date;
        }
    }
}