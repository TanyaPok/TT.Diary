using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Repositories;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    public class GetPlannerHandler : IRequestHandler<GetPlannerQuery, Planner>
    {
        private readonly TrackedHabitsContainerRepository _habitsRepository;
        private readonly NotesContainerRepository _notesRepository;

        public GetPlannerHandler(TrackedHabitsContainerRepository habitsRepository,
            NotesContainerRepository notesRepository)
        {
            _habitsRepository = habitsRepository ?? throw new ArgumentNullException(nameof(habitsRepository));
            _notesRepository = notesRepository ?? throw new ArgumentNullException(nameof(notesRepository));
        }

        public Task<Planner> Handle(GetPlannerQuery request, CancellationToken cancellationToken)
        {
            var planner = new Planner
            {
                Habits = _habitsRepository.GetTrackedList(request.UserId, request.StartDate.Date,
                    request.FinishDate.Date)
            };

            // filter by repeated options
            for (var i = planner.Habits.Count - 1; i >= 0; i--)
            {
                planner.Habits[i].Schedule.SetTrackerStrategy();

                if (!planner.Habits[i].Schedule.TryGenerateTrackers(request.StartDate.Date, request.FinishDate.Date))
                {
                    planner.Habits.Remove(planner.Habits[i]);
                }
            }

            planner.Notes = _notesRepository.GetNotes(request.UserId, request.StartDate.Date, request.FinishDate.Date);

            return Task.FromResult(planner);
        }
    }
}