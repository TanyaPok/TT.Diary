using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractRemoveTrackerHandler<TOwner, TCommand> : AsyncRequestHandler<TCommand>
        where TOwner : TrackedAbstractItem
        where TCommand : AbstractRemoveTrackerCommand
    {
        private readonly DiaryDBContext _context;

        protected AbstractRemoveTrackerHandler(DiaryDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected override async Task Handle(TCommand request, CancellationToken cancellationToken)
        {
            var owner = _context.Get<TOwner, Tracker>(request.OwnerId, o => o.Trackers);
            _context.RemoveRange(owner.Trackers);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}