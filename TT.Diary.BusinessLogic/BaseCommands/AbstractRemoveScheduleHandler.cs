using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractRemoveScheduleHandler<TCommand, TOwner> : AsyncRequestHandler<TCommand>
        where TCommand : AbstractRemoveCommand
        where TOwner : AbstractItem
    {
        private readonly DiaryDBContext _context;

        protected AbstractRemoveScheduleHandler(DiaryDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected override async Task Handle(TCommand request, CancellationToken cancellationToken)
        {
            var schedule = _context.GetSchedule(request.Id);
            var owner = schedule.Owner;
            owner.Schedule = null;
            _context.Remove(schedule);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}