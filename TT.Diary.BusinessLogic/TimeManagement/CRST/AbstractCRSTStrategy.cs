using System;
using System.Collections.Generic;
using System.Linq;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.TimeManagement.CRST
{
    internal abstract class AbstractCRSTStrategy
    {
        internal abstract bool TryGenerateTrackers(DateTime startDate, DateTime finishDate, ScheduleSettings schedule);

        protected DateTime GetFinishDate(DateTime finishDate, DateTime? scheduledCompletionDate,
            DateTime? completionDate)
        {
            if (completionDate.HasValue && completionDate.Value < finishDate)
            {
                return completionDate.Value.Date.AddDays(1).AddSeconds(-1);
            }

            if (scheduledCompletionDate.HasValue && scheduledCompletionDate.Value < finishDate)
            {
                return scheduledCompletionDate.Value.Date.AddDays(1).AddSeconds(-1);
            }

            return finishDate.Date.AddDays(1).AddSeconds(-1);
        }

        protected void SetTracker(IList<Tracker> trackers, DateTime date)
        {
            var tracker = trackers.FirstOrDefault(t => t.ScheduledDate == date);

            if (tracker == null)
            {
                trackers.Add(
                    new Tracker()
                    {
                        ScheduledDate = date,
                        DateTime = null,
                        Progress = 0,
                        Significance = 0.0,
                        Value = null
                    });
            }
        }
    }
}