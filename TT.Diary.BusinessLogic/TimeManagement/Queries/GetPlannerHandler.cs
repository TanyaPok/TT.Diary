using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.DTO.Lists;
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

            planner.Notes = (from u in _context.Users
                             join c in _context.Categories on u.Id equals c.UserId
                             join n in _context.Notes on c.Id equals n.CategoryId
                             into result
                             from r in result.DefaultIfEmpty()
                             where u.Id == request.UserId && (r.ScheduleDateUtc.Date >= request.StartDate.Date && r.ScheduleDateUtc.Date <= request.FinishDate.Date)
                             select new Note
                             {
                                 Id = r.Id,
                                 Description = r.Description,
                                 ScheduleDate = r.ScheduleDateUtc
                             }).ToList();

            return Task.FromResult(planner);
        }
    }
}
