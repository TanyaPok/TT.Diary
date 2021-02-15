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

    public class ScheduleSettings : AbstractScheduleSettings
    {
        private AbstractCRSTStrategy _strategy;

        public Repeat Repeat { get; set; }

        public uint Every { get; set; }

        public Months Months { get; set; }

        public Weekdays Weekdays { get; set; }

        public uint DaysAmount { set; get; }

        public IList<Tracker> Trackers { set; get; }

        internal void SetTrackerStrategy(Strategy strategy = Strategy.Planner)
        {
            switch (Repeat)
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
                default: throw new ArgumentException(nameof(Repeat));
            }
        }

        internal bool TryGenerateTrackers(DateTime startDate, DateTime finishDate)
        {
            return _strategy != null && _strategy.TryGenerateTrackers(startDate, finishDate, this);
        }
    }
}