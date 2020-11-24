using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractRemoveTrackedHandler<TCommand, TOwner> : AsyncRequestHandler<TCommand>
        where TCommand : AbstractRemoveScheduledCommand
        where TOwner : TrackedAbstractItem
    {
        private readonly DiaryDBContext _context;

        protected AbstractRemoveTrackedHandler(DiaryDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected override async Task Handle(TCommand request, CancellationToken cancellationToken)
        {
            var owner = _context.GetTrackedItem<TOwner>(request.OwnerId);
            _context.Remove(owner.Schedule);

            if (owner.Trackers.Count > 0)
            {
                _context.Remove(owner.Trackers);
            }

            if (request.WithOwner)
            {
                _context.Remove(owner);
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}