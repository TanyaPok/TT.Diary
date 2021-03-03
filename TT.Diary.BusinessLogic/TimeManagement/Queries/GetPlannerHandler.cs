using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Repositories;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    public class GetPlannerHandler : IRequestHandler<GetPlannerQuery, Planner>
    {
        private readonly TrackedHabitsContainerRepository _habitsRepository;
        private readonly TrackedToDoListContainerRepository _todoListRepository;
        private readonly NotesContainerRepository _notesRepository;
        private readonly WishListContainerRepository _wishListContainerRepository;

        public GetPlannerHandler(TrackedHabitsContainerRepository habitsRepository,
            TrackedToDoListContainerRepository todoListRepository,
            NotesContainerRepository notesRepository, WishListContainerRepository wishListContainerRepository)
        {
            _habitsRepository = habitsRepository ?? throw new ArgumentNullException(nameof(habitsRepository));
            _todoListRepository = todoListRepository ?? throw new ArgumentNullException(nameof(todoListRepository));
            _notesRepository = notesRepository ?? throw new ArgumentNullException(nameof(notesRepository));
            _wishListContainerRepository = wishListContainerRepository ?? throw new ArgumentNullException(nameof(wishListContainerRepository));
        }

        public Task<Planner> Handle(GetPlannerQuery request, CancellationToken cancellationToken)
        {
            var planner = new Planner
            {
                Habits = _habitsRepository.GetTrackedList(request.UserId, request.StartDate.Date,
                    request.FinishDate.Date)
            };
            Filter<Habit<ScheduleSettings>>(planner.Habits, request.StartDate, request.FinishDate);

            planner.ToDoList = _todoListRepository.GetTrackedList(request.UserId, request.StartDate.Date,
                request.FinishDate.Date);
            Filter<ToDo<ScheduleSettings>>(planner.ToDoList, request.StartDate, request.FinishDate);

            planner.Notes = _notesRepository.GetNotes(request.UserId, request.StartDate.Date, request.FinishDate.Date);
            
            planner.WishList = _wishListContainerRepository.GetScheduledList(request.UserId, request.StartDate.Date,
                request.FinishDate.Date);

            return Task.FromResult(planner);
        }

        private void Filter<TDto>(IList<TDto> list, DateTime startDate, DateTime finishDate)
            where TDto : AbstractScheduledItem<ScheduleSettings>
        {
            // filter by repeated options
            for (var i = list.Count - 1; i >= 0; i--)
            {
                list[i].Schedule.SetTrackerStrategy();

                if (!list[i].Schedule.TryGenerateTrackers(startDate.Date, finishDate.Date))
                {
                    list.Remove(list[i]);
                }
            }
        }
    }
}