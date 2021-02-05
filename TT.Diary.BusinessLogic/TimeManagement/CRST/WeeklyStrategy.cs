using System;
using System.Collections.Generic;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.TimeManagement.CRST
{
    internal class WeeklyStrategy : CRSTStrategy
    {
        private readonly IDictionary<DayOfWeek, DataAccessLogic.Model.TimeManagement.Weekdays> _translationDic;

        internal WeeklyStrategy()
        {
            _translationDic = new Dictionary<DayOfWeek, DataAccessLogic.Model.TimeManagement.Weekdays>
            {
                { DayOfWeek.Monday, DataAccessLogic.Model.TimeManagement.Weekdays.Monday },
                { DayOfWeek.Tuesday, DataAccessLogic.Model.TimeManagement.Weekdays.Tuesday },
                { DayOfWeek.Wednesday, DataAccessLogic.Model.TimeManagement.Weekdays.Wednesday },
                { DayOfWeek.Thursday, DataAccessLogic.Model.TimeManagement.Weekdays.Thursday },
                { DayOfWeek.Friday, DataAccessLogic.Model.TimeManagement.Weekdays.Friday },
                { DayOfWeek.Saturday, DataAccessLogic.Model.TimeManagement.Weekdays.Saturday },
                { DayOfWeek.Sunday, DataAccessLogic.Model.TimeManagement.Weekdays.Sunday }
            };
        }

        internal override bool TryGenerateTrackers(DateTime startDate, DateTime finishDate, ScheduleSettings schedule)
        {
            var date = schedule.ScheduledStartDateTime;
            var finish = GetFinishDate(finishDate, schedule.ScheduledCompletionDate, schedule.CompletionDate);

            while (date < startDate)
            {
                date = GetNextDate(schedule.Weekdays, schedule.Every, date);
            }

            if (date > finish)
            {
                return false;
            }

            do
            {
                SetTracker(schedule.Trackers, date);
                date = GetNextDate(schedule.Weekdays, schedule.Every, date);
            } while (date <= finish);

            return true;
        }

        private DateTime GetNextDate(DataAccessLogic.Model.TimeManagement.Weekdays weekdays, uint every, DateTime date)
        {
            var nextDate = date.AddDays(1);
            var weekDay = (int)_translationDic[nextDate.DayOfWeek];
            var iteration = weekDay;

            do
            {
                for (var i = weekDay; i <= 64; i *= 2)
                {
                    if (!weekdays.HasFlag((DataAccessLogic.Model.TimeManagement.Weekdays)i))
                    {
                        continue;
                    }

                    int countDays;

                    if (i >= iteration)
                    {
                        countDays = (int)Math.Log2(i) - (int)Math.Log2(iteration);
                    }
                    else
                    {
                        countDays = 7 - (int)Math.Log2(iteration) - (int)Math.Log2(i);
                    }

                    return nextDate.AddDays(countDays);
                }

                weekDay = (int)_translationDic[DayOfWeek.Monday];
                nextDate = nextDate.AddDays((nextDate.DayOfWeek == DayOfWeek.Monday) ? 0 : 7 - (int)nextDate.DayOfWeek + 1);
                iteration = weekDay;
                nextDate = nextDate.AddDays((every - 1) * 7);
            } while (true);
        }
    }
}
