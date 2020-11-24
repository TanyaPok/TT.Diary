using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    public class GetAnnualProductivityHandler : IRequestHandler<GetAnnualProductivityQuery, List<DailyProductivity>>
    {
        private readonly DiaryDBContext _context;
        private readonly DataReceiver _dataReceiver;

        public GetAnnualProductivityHandler(DiaryDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dataReceiver = new DataReceiver();
        }

        public Task<List<DailyProductivity>> Handle(GetAnnualProductivityQuery request, CancellationToken cancellationToken)
        {
            var annualProductivities = new List<DailyProductivity>();

            // initial data selection
            var toDoList = _dataReceiver.GetToDoList(_context, request.UserId, request.StartDate.Date, request.FinishDate.Date);

            // filter by repeated options
            for (int i = toDoList.Count - 1; i >= 0; i--)
            {
                toDoList[i].SetTrackerStrategy(Strategy.AnnualProductivity);

                if (!toDoList[i].TryGenerateTrackers(request.StartDate.Date, request.FinishDate.Date))
                {
                    toDoList.Remove(toDoList[i]);
                }
            }

            var groups = toDoList.SelectMany(t => t.Trackers).GroupBy(t => t.ScheduledDate.Date).OrderBy(t => t.Key);

            foreach (var key in groups)
            {
                annualProductivities.Add(
                    new DailyProductivity()
                    {
                        Date = key.Key,
                        Productivity = key.Average(t => t.Significance)
                    });
            }

            return Task.FromResult(annualProductivities);
        }
    }
}
