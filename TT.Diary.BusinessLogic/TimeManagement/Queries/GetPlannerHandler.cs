using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    public class GetPlannerHandler : IRequestHandler<GetPlannerQuery, Planner>
    {
        private readonly DiaryDBContext _context;
        private readonly DataReceiver _dataReceiver;

        public GetPlannerHandler(DiaryDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dataReceiver = new DataReceiver();
        }

        public Task<Planner> Handle(GetPlannerQuery request, CancellationToken cancellationToken)
        {
            Planner planner = new Planner();

            planner.Habits = _dataReceiver.GetHabits(_context, request.UserId, request.StartDate.Date, request.FinishDate.Date);
            // filter by repeated options
            for (int i = planner.Habits.Count - 1; i >= 0; i--)
            {
                planner.Habits[i].SetTrackerStrategy();

                if (!planner.Habits[i].TryGenerateTrackers(request.StartDate.Date, request.FinishDate.Date))
                {
                    planner.Habits.Remove(planner.Habits[i]);
                }
            }

            planner.Notes = _dataReceiver.GetNotes(_context, request.UserId, request.StartDate.Date, request.FinishDate.Date);
            return Task.FromResult(planner);
        }
    }
}
