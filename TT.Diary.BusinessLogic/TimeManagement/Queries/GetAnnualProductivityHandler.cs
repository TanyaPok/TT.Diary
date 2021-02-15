using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Repositories;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    public class GetAnnualProductivityHandler : IRequestHandler<GetAnnualProductivityQuery, List<DailyProductivity>>
    {
        private readonly TrackedToDoListContainerRepository _repository;

        public GetAnnualProductivityHandler(TrackedToDoListContainerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<DailyProductivity>> Handle(GetAnnualProductivityQuery request,
            CancellationToken cancellationToken)
        {
            // initial data selection
            var toDoList = _repository.GetTrackedList(request.UserId, request.StartDate.Date, request.FinishDate.Date);

            // filter by repeated options
            for (var i = toDoList.Count - 1; i >= 0; i--)
            {
                toDoList[i].Schedule.SetTrackerStrategy(Strategy.AnnualProductivity);

                if (!toDoList[i].Schedule.TryGenerateTrackers(request.StartDate.Date, request.FinishDate.Date))
                {
                    toDoList.Remove(toDoList[i]);
                }
            }

            var groups = toDoList.SelectMany(t => t.Schedule.Trackers).GroupBy(t => t.ScheduledDate.Date)
                .OrderBy(t => t.Key);

            var annualProductivity = groups.Select(key => new DailyProductivity()
                {Date = key.Key, Productivity = key.Average(t => t.Significance)}).ToList();

            return Task.FromResult(annualProductivity);
        }
    }
}