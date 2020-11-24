using System;
using System.Collections.Generic;
using TT.Diary.BusinessLogic.TimeManagement.CRST;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.BusinessLogic.DTO.TimeManagement
{
    public enum Strategy
    {
        AnnualProductivity,
        Planner
    }

    public abstract class AbstractItem
    {
        private CRSTStrategy _strategy;

        public int Id { get; set; }

        public string Description { set; get; }

        public int ParentId { get; set; }

        public ScheduleSettings Schedule { get; set; }

        public IList<Tracker> Trackers { set; get; }

        internal void SetTrackerStrategy(Strategy strategy = Strategy.Planner)
        {
            if (Schedule == null)
            {
                _strategy = null;
                return;
            }

            switch (Schedule.Repeat)
            {
                case Repeat.None:
                    if (strategy == Strategy.AnnualProductivity)
                    {
                        _strategy = new SimpleAnnualProductivityStrategy();
                        break;
                    }

                    _strategy = new SimplePlannerStrategy();
                    break;
                case Repeat.Daily:
                    _strategy = new DailyStrategy();
                    break;
                case Repeat.Weekly:
                    _strategy = new WeeklyStrategy();
                    break;
                case Repeat.Monthly:
                    _strategy = new MonthlyStrategy();
                    break;
                case Repeat.Yearly:
                    _strategy = new YearlyStrategy();
                    break;
                default: throw new ArgumentException(nameof(Schedule.Repeat));
            }
        }

        internal bool TryGenerateTrackers(DateTime startDate, DateTime finishDate)
        {
            if (_strategy == null)
            {
                return false;
            }

            return _strategy.TryGenerateTrackers(startDate, finishDate, Schedule, Trackers);
        }
    }
}