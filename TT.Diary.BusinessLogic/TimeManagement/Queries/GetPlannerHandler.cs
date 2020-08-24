using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    public class GetPlannerHandler : IRequestHandler<GetPlannerQuery, Planner>
    {
        private readonly DiaryDBContext _context;

        public GetPlannerHandler(DiaryDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Planner> Handle(GetPlannerQuery request, CancellationToken cancellationToken)
        {
            Planner planner = new Planner();

            planner.ToDoList = (from u in _context.Users
                                      join c in _context.Categories on u.Id equals c.UserId
                                      join t in _context.ToDoList on c.Id equals t.CategoryId
                                      join s in _context.Schedules on t.ScheduleId equals s.Id
                                      into result
                                      from r in result.DefaultIfEmpty()
                                      where u.Id == request.UserId && (r.ScheduledStartDateUtc.Date >= request.StartDate.Date && r.ScheduledStartDateUtc.Date <= request.FinishDate.Date)
                                      select new ToDo
                                      {
                                          Id = t.Id,
                                          Description = t.Description,
                                          ParentCategoryId = c.Id,
                                          ParentCategoryDescription = c.Description,
                                          Schedule = new DTO.Schedule()
                                          {
                                              Id = r.Id,
                                              ScheduledStartDateUtc = r.ScheduledStartDateUtc,
                                              StartDateUtc = r.StartDateUtc,
                                              ScheduledCompletionDateUtc = r.ScheduledCompletionDateUtc,
                                              CompletionDateUtc = r.CompletionDateUtc
                                          }
                                      }).ToList();

            return Task.FromResult(planner);
        }
    }
}
