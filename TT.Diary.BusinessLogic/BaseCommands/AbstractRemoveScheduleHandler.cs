using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractRemoveScheduleHandler<TCommand, TSchedule> : AsyncRequestHandler<TCommand>
        where TCommand : AbstractRemoveCommand
        where TSchedule : ScheduleSettings
    {
        private readonly AbstractBaseRepository<TSchedule> _repository;

        protected AbstractRemoveScheduleHandler(AbstractBaseRepository<TSchedule> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        protected override async Task Handle(TCommand request, CancellationToken cancellationToken)
        {
            var schedule = _repository.Get(request.Id, s => s.Owner);
            var owner = schedule.Owner;
            owner.Schedule = null;
            await _repository.RemoveAsync(schedule, cancellationToken);
        }
    }
}