using System;
using System.Collections.Generic;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.TimeManagement.CRST
{
    internal class YearlyStrategy : AbstractCRSTStrategy
    {
        private readonly IDictionary<int, DataAccessLogic.Model.TimeManagement.Months> _translationDic;

        internal YearlyStrategy()
        {
            _translationDic = new Dictionary<int, DataAccessLogic.Model.TimeManagement.Months>
            {
                {1, DataAccessLogic.Model.TimeManagement.Months.January},
                {2, DataAccessLogic.Model.TimeManagement.Months.February},
                {3, DataAccessLogic.Model.TimeManagement.Months.March},
                {4, DataAccessLogic.Model.TimeManagement.Months.April},
                {5, DataAccessLogic.Model.TimeManagement.Months.May},
                {6, DataAccessLogic.Model.TimeManagement.Months.June},
                {7, DataAccessLogic.Model.TimeManagement.Months.July},
                {8, DataAccessLogic.Model.TimeManagement.Months.August},
                {9, DataAccessLogic.Model.TimeManagement.Months.September},
                {10, DataAccessLogic.Model.TimeManagement.Months.October},
                {11, DataAccessLogic.Model.TimeManagement.Months.November},
                {12, DataAccessLogic.Model.TimeManagement.Months.December}
            };
        }

        internal override bool TryGenerateTrackers(DateTime startDate, DateTime finishDate, ScheduleSettings schedule)
        {
            var date = schedule.ScheduledStartDateTime;
            var finish = GetFinishDate(finishDate, schedule.ScheduledCompletionDate, schedule.CompletionDate);
            var startDay = date.Day - 1;

            while (date.AddDays(schedule.DaysAmount) < startDate)
            {
                date = GetNextDate(schedule.Months, schedule.Every, startDay, date);
            }

            if (date > finish)
            {
                return false;
            }

            do
            {
                SetTracker(schedule.Trackers, date);
                date = GetNextDate(schedule.Months, schedule.Every, startDay, date);
            } while (date <= finish);

            return true;
        }

        private DateTime GetNextDate(DataAccessLogic.Model.TimeManagement.Months months, uint every, int startDay,
            DateTime date)
        {
            var nextDate = date.AddDays(DateTime.DaysInMonth(date.Year, date.Month) - date.Day + 1);
            var month = (int) _translationDic[nextDate.Month];
            var iteration = month;

            do
            {
                for (var i = month; i <= 2048; i *= 2)
                {
                    if (!months.HasFlag((DataAccessLogic.Model.TimeManagement.Months) i))
                    {
                        continue;
                    }

                    int countMonths;

                    if (i >= iteration)
                    {
                        countMonths = (int) Math.Log2(i) - (int) Math.Log2(iteration);
                    }
                    else
                    {
                        countMonths = 12 - (int) Math.Log2(iteration) - (int) Math.Log2(i);
                    }

                    nextDate = nextDate.AddMonths(countMonths);
                    nextDate = nextDate.AddDays(startDay);
                    return nextDate;
                }

                month = (int) _translationDic[1];
                nextDate = nextDate.AddMonths((nextDate.Month == 1) ? 0 : 12 - (int) nextDate.Month + 1);
                iteration = month;
                nextDate = nextDate.AddYears((int) every - 1);
            } while (true);
        }
    }
}