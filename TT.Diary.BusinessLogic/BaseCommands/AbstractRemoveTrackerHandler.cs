using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractRemoveTrackerHandler<TContainer, TCommand> : AsyncRequestHandler<TCommand>
        where TContainer : TrackedAbstractItem
        where TCommand : AbstractRemoveTrackerCommand
    {
        private readonly AbstractBaseTrackedContainerRepository<TContainer> _repository;

        protected AbstractRemoveTrackerHandler(AbstractBaseTrackedContainerRepository<TContainer> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        protected override async Task Handle(TCommand request, CancellationToken cancellationToken)
        {
            var owner = _repository.GetFirstLevel(request.OwnerId, o => o.Trackers);
            await _repository.RemoveFromAsync(owner, owner.Trackers, cancellationToken);
        }
    }
}